using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : Monobehaviour 
{
  void Start()
  {
  
  }
  void Update()
  {
  
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
      {
        SceneManager.LoadScene(1);
      }
  }
  
}

  
