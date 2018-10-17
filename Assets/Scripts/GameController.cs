using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
  public static bool blueTurn;

  public static void InitializeGame()
  {
    ResetPlayArea();
    WRMVGame.GameController.createGame();
    WRMVGame.GameController.beginGame();
    //set cards
    for (int i = 0; i < 5; i++)
      {
        setCard(WRMVGame.GameController.cardsInPlay[i].nameOfMove,i);
      }
    //set first move
    if (WRMVGame.GameController.blueFirst.Value)
      {
        blueTurn = true;
        GameObject.Find("txtPlayerTurn").GetComponent<Text>().text = "Rebel's turn";
      }
    else
      {
        blueTurn = false;
        GameObject.Find("txtPlayerTurn").GetComponent<Text>().text = "Empire's turn";       
        setCamera();
      }         
  }

  public static void setCamera()
    {
      GameObject gA = GameObject.Find("PlayArea");
      GameObject B1 = GameObject.Find("CardB1");   
      GameObject B2 = GameObject.Find("CardB2");
      GameObject R1 = GameObject.Find("CardR1");
      GameObject R2 = GameObject.Find("CardR2");  
      if (blueTurn)
        {                                                           
          gA.transform.RotateAround(new Vector3(0,0,0), gA.transform.right, -60f);
          gA.transform.RotateAround(new Vector3(0,0,0), gA.transform.up, -180f);
          B1.transform.Translate(0,0,50);
          B1.transform.localScale += new Vector3(0.33f,0,0.33f);
          B2.transform.Translate(0,0,50);            
          B2.transform.localScale += new Vector3(0.33f,0,0.33f);
          R1.transform.Translate(0,0,-50);
          R1.transform.localScale -= new Vector3(0.33f,0,0.33f);
          R2.transform.Translate(0,0,-50);             
          R2.transform.localScale -= new Vector3(0.33f,0,0.33f);
        }
      else
        {                                   
          gA.transform.RotateAround(new Vector3(0,0,0), gA.transform.right, -60f);
          gA.transform.RotateAround(new Vector3(0,0,0), gA.transform.up, -180f); 
          B1.transform.Translate(0,0,-50);             
          B1.transform.localScale -= new Vector3(0.33f,0,0.33f);
          B2.transform.Translate(0,0,-50);             
          B2.transform.localScale -= new Vector3(0.33f,0,0.33f);
          R1.transform.Translate(0,0,50);            
          R1.transform.localScale += new Vector3(0.33f,0,0.33f);
          R2.transform.Translate(0,0,50);            
          R2.transform.localScale += new Vector3(0.33f,0,0.33f);

        }
    }

  public static void setCard(string name, int i)
  {
    switch (i)
      {
        case 0:
          {
            GameObject card = GameObject.Find("CardB1");
            MeshRenderer[] renderers = card.GetComponentsInChildren<MeshRenderer>(true); 
            renderers[CardNameToInt(name)].gameObject.SetActive(true);
            break;
          }
        case 1:
          {
            GameObject card = GameObject.Find("CardR1");
            MeshRenderer[] renderers = card.GetComponentsInChildren<MeshRenderer>(true);        
            renderers[CardNameToInt(name)].gameObject.SetActive(true);
            break;
          }
        case 2:
          {
            GameObject card = GameObject.Find("CardB2");
            MeshRenderer[] renderers = card.GetComponentsInChildren<MeshRenderer>(true); 
            renderers[CardNameToInt(name)].gameObject.SetActive(true);
            break;
          }
        case 3:
          {
            GameObject card = GameObject.Find("CardR2");            
            MeshRenderer[] renderers = card.GetComponentsInChildren<MeshRenderer>(true);   
            renderers[CardNameToInt(name)].gameObject.SetActive(true);
            break;
          }
        default:
          {
            GameObject card = GameObject.Find("CardQ");            
            MeshRenderer[] renderers = card.GetComponentsInChildren<MeshRenderer>(true); 
            renderers[CardNameToInt(name)].gameObject.SetActive(true);
            break;
          }
      }
  }

  public static void setTurnText()
    {
      if (blueTurn)
        {                  
          GameObject.Find("txtPlayerTurn").GetComponent<Text>().text = "Rebel's turn";
        }
      else
        {                   
          GameObject.Find("txtPlayerTurn").GetComponent<Text>().text = "Empire's turn";
        }
    }

  public static int CardNameToInt(string name)
    {
      if (name == "Ashla")
        {
          return 0;
        }
      else if (name == "Ataru")
        {
          return 1;
        }
      else if (name == "Bogan")
        {
          return 2;
        }
      else if (name == "Djem So")
        {
          return 3;
        }
      else if (name == "Dun Moch")
        {
          return 4;
        }
      else if (name == "Form Zero")
        {
          return 5;
        }
      else if (name == "Jar Kai")
        {
          return 6;
        }
      else if (name == "Lus-ma")
        {
          return 7;
        }
      else if (name == "Makashi")
        {
          return 8;
        }
      else if (name == "Niman")
        {
          return 9;
        }
      else if (name == "Shii-Cho")
        {
          return 10;
        }
      else if (name == "Sokan")
        {
          return 11;
        }
      else if (name == "Soresu")
        {
          return 12;
        }
      else if (name == "Trakata")
        {
          return 13;
        }
      else if (name == "Trispzest")
        {
          return 14;
        }
      else
        {
          return 15;
        } 
    }

  public static void ResetPlayArea()
  {
    GameObject.Find("txtPlayerTurn").GetComponent<Text>().text = "Turn";
    for (int i = 0; i < 5; i++)
      {
        for (int j = 0; j < 5; j++)
          {
            GameObject square = GameObject.Find("sqr"+i.ToString()+j.ToString());  
            MeshRenderer[] renderers = square.GetComponentsInChildren<MeshRenderer>(true);
            renderers[1].enabled = false;
          }
        GameObject rP = GameObject.Find("RedP"+i.ToString());
        GameObject bP = GameObject.Find("BlueP"+i.ToString());
        rP.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
        bP.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
        if (i == 2)
          {
            rP.transform.position.Set(i*10f-20f,13.2f,16.1f);
            bP.transform.position.Set(i*10f-20f,-7.4f,-19.5f);
          }
        else
          {
            rP.transform.position.Set(i*10f-20f,11.2f,17.3f);
            bP.transform.position.Set(i*10f-20f,-9.8f,-19f);
          }
      }
    GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
    foreach (GameObject card in cards)
      {
        MeshRenderer[] renderers = card.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
          {
            renderer.material.shader = Shader.Find("VertexLit");   
            renderer.gameObject.SetActive(false);
          }
      }
  }
	
}
