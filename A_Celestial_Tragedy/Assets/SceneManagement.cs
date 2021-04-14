using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public string nameOfScene; 
 private void OnTriggerEnter(Collider other) {
     if(other.gameObject.tag== "Player") {
    SceneManager.LoadScene(nameOfScene);
    

     }
 }
}
