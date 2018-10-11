using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigation : MonoBehaviour {

  public void Magic()
  {
    Text t = GameObject.FindGameObjectWithTag("test").GetComponent<Text>();
    t.text = "Hello World";
  }
  public void Magic2()
  {
    Text t = GameObject.FindGameObjectWithTag("test").GetComponent<Text>();
    t.text = "Fek off m8";
  }
  public void NewGame()
  {
    SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
  }
  public void ExitGame()
  {
    SceneManager.LoadScene("ExitMenu",LoadSceneMode.Additive);
  }
  public void StartGame()
  {
    //SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
    SceneManager.UnloadSceneAsync("ExitMenu");
  }
  public void StopGame()
  {
    SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
  }
  public void RuleBook()
  {
    SceneManager.LoadScene("RuleBook",LoadSceneMode.Single);
  } 
	public void BackClick()
  {
    SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
  }
  public void QuitGame()
  {
    #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
    #else
      Application.Quit();
    #endif
  }
}
