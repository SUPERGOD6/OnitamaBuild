using System.Collections;
using System.Collections.Generic;
using UnityEngine;                 

public class GameLoad : MonoBehaviour { 
  public static bool pieceSelected, cardSelected;
  public static GameObject piece, card;
  public static List<GameObject> highlightedSquares;
                                
	public IEnumerator Start ()
  {
	  yield return StartCoroutine(wait());
    ResetGame();
	}   
  public IEnumerator wait()
  {                         
    yield return new WaitForSecondsRealtime(0.1f);    
  }
	private static void ResetGame()
  { 
    highlightedSquares = new List<GameObject>();
    GameController.InitializeGame();
  }
}
