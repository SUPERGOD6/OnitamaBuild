using System.Collections;           
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {

	public IEnumerator Start () {
		 yield return StartCoroutine(wait());
     if (ClickyClick.winner)
       {
         GameObject.Find("txtWinner").GetComponent<Text>().text = "Congratulations to the Rebels!\n\nStart new game or return to main menu?";
       }
     else
       {
         GameObject.Find("txtWinner").GetComponent<Text>().text = "Congratulations to the Empire!\n\nStart new game or return to main menu?";
       }
	}
	
	public IEnumerator wait()
  {                         
    yield return new WaitForSecondsRealtime(0.1f);    
  }
}
