using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigation : MonoBehaviour {
   
  private void ResetGame()
  { 
    GameController.InitializeGame();
  }
  public void NewGame()
  {
    SceneManager.LoadScene("GameScene",LoadSceneMode.Single);                                                 
  }   
  public void ExitGame()
  {
    SceneManager.LoadScene("ExitMenu",LoadSceneMode.Additive);
  }   
  public void ResignGame()
  {
    SceneManager.LoadScene("ResignMenu",LoadSceneMode.Additive);          
  }        
  public void ReloadGame()
  {   
    SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
  }
  public void ReloadGame2()
  {                 
    SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
  }
  public void StartGame3()
  {
    SceneManager.UnloadSceneAsync("WinMenu");
  }
  public void StartGame2()
  {                                                             
    SceneManager.UnloadSceneAsync("ResignMenu");
  }
  public void StartGame()
  {                                                             
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
