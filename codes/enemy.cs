using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform patrolPointA;
    public Transform patrolPointB;
    public float triggerDistance = 1f;

    private Rigidbody2D rb;
    private Vector2 currentPosition;
    private Vector2 nextPoint;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = rb.position;
        nextPoint = patrolPointA.position;
    }

    void FixedUpdate()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        currentPosition = rb.position;

        // determine the next point to move towards
        if (Vector2.Distance(currentPosition, nextPoint) <= triggerDistance)
        {
            // switch direction if close to the current point
            if (movingRight)
            {
                nextPoint = patrolPointB.position;
                FlipSprite();
                movingRight = false;
            }
            else
            {
                nextPoint = patrolPointA.position;
                FlipSprite();
                movingRight = true;
            }
        }

        // move towards the next point
        Vector2 direction = (nextPoint - currentPosition).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        // flip the sprite to face the correct direction
        transform.localScale = new Vector3(movingRight ? 1 : -1, transform.localScale.y, transform.localScale.z);
    }
}
