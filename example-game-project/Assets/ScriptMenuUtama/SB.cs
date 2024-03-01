using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SB : MonoBehaviour
{
   public void ChangeScene(string sceneChange)
   {
	   SceneManager.LoadScene(sceneChange);
   }	   
}
