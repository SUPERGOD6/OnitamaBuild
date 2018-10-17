using UnityEngine;
using UnityEngine.SceneManagement;  

public class ClickyClick : MonoBehaviour {     
  private string Objname;
  public static bool winner;

  public void OnMouseDown()
    {                                 
      if (SceneManager.sceneCount == 1)
        {
          Objname = this.gameObject.name;   
          if (Objname.Contains("sqr"))
            {
              SquareClick();
            }
          else if (Objname.Contains("Card"))
            {
              CardClick();
            }
          else
            {
              PieceClick();
            } 
        }
    }
	public void CardClick()
    {     
      if ((GameController.blueTurn && Objname.Contains("B")) || (!GameController.blueTurn && Objname.Contains("R")))
        {
          if (GameLoad.cardSelected)
            {
              if (GameLoad.card.name == Objname)    //unselect
                {
                  GameLoad.cardSelected = false;
                  this.gameObject.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");  
                  if (GameLoad.pieceSelected)
                    {
                      foreach (GameObject sqr in GameLoad.highlightedSquares)
                        {
                          sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = false;
                        }
                      GameLoad.highlightedSquares.Clear();
                    }                
                }                                                 
              else //select other card
                {
                  GameLoad.card.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
                  GameLoad.card = this.gameObject;
                  this.gameObject.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Diffuse");
                  if (GameLoad.pieceSelected)
                    {
                      foreach (GameObject sqr in GameLoad.highlightedSquares)
                        {
                          sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = false;
                        }
                      GameLoad.highlightedSquares.Clear();                    
                      selectTiles(GameLoad.card, GameLoad.piece);
                      foreach (GameObject sqr in GameLoad.highlightedSquares)
                        {
                          sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = true;
                        }
                    }                       
                }
            }
          else //select card
            {
              GameLoad.cardSelected = true;
              GameLoad.card = this.gameObject;                               
              this.gameObject.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Diffuse");
              if (GameLoad.pieceSelected)
                {                    
                  selectTiles(GameLoad.card, GameLoad.piece);
                  foreach (GameObject sqr in GameLoad.highlightedSquares)
                    {
                      sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = true;
                    }
                }                
            }
        }
    }

  public void PieceClick()
    {
      if ((GameController.blueTurn && Objname.Contains("Blue")) || (!GameController.blueTurn && Objname.Contains("Red")))
        {
          if (GameLoad.pieceSelected)
            {
              if (GameLoad.piece.name == Objname) //unselect
                {
                  GameLoad.pieceSelected = false;
                  this.gameObject.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
                  if (GameLoad.cardSelected)
                    {
                      foreach (GameObject sqr in GameLoad.highlightedSquares)
                        {
                          sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = false;
                        }
                      GameLoad.highlightedSquares.Clear();
                    }
                }
              else //select other piece
                {
                  GameLoad.piece.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
                  GameLoad.piece = this.gameObject;
                  this.gameObject.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Diffuse");
                  if (GameLoad.cardSelected)
                    {
                      foreach (GameObject sqr in GameLoad.highlightedSquares)
                        {
                          sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = false;
                        }
                      GameLoad.highlightedSquares.Clear();                   
                      selectTiles(GameLoad.card, GameLoad.piece);
                      foreach (GameObject sqr in GameLoad.highlightedSquares)
                        {
                          sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = true;
                        }
                    }
                }
            }
          else //select
            {
              GameLoad.pieceSelected = true;
              GameLoad.piece = this.gameObject;
              this.gameObject.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("Diffuse");
              if (GameLoad.cardSelected)
                {                                        
                  selectTiles(GameLoad.card, GameLoad.piece);
                  foreach (GameObject sqr in GameLoad.highlightedSquares)
                    {
                      sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = true;
                    }
                }
            }
        }
      
    }

  public void SquareClick()
    {       
      if (this.GetComponentsInChildren<MeshRenderer>(true)[1].enabled)
        {
          //Get variables
          GameObject card = GameLoad.card, piece = GameLoad.piece, square = this.gameObject, q = GameObject.Find("CardQ");    
          WRMVGame.Card Card = WRMVGame.GameController.findCard(card.GetComponentInChildren<MeshRenderer>().gameObject.name.Substring(0,3)); 
          int Ox = fPx(piece.transform), Oy = fPy(piece.transform); WRMVGame.Cell OSquare = WRMVGame.GameController.board[Ox,Oy];
          WRMVGame.Piece Piece = WRMVGame.GameController.findPiece(Ox,Oy);  
          int Nx = int.Parse(square.name[3].ToString()), Ny = int.Parse(square.name[4].ToString());  
          WRMVGame.Cell Square = WRMVGame.GameController.board[Nx,Ny];     
          WRMVGame.Card Q = WRMVGame.GameController.findUnassignedCard(); 

          //If capturing
          if (Square.isOccupied)
            {
              WRMVGame.GameController.findPiece(Nx,Ny).captured = true;
              GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");
              foreach (GameObject capturedPiece in pieces)
                {
                  int Tx = fPx(capturedPiece.transform), Ty = fPy(capturedPiece.transform);
                  if (Tx == Nx && Ty == Ny)
                    {
                      capturedPiece.SetActive(false);
                    }
                }
            }  

          //Move piece
          Piece.x = Nx; Piece.y = Ny;   
          piece.transform.localPosition += new Vector3((Nx-Ox)*10f,(Oy-Ny)*5.25f,(Oy-Ny)*9.075f); 

          //Set new square occupied
          Square.isOccupied = true;   
          Square.isOccupiedWithBlue = GameController.blueTurn;  
          Square.isOccupiedWithMaster = Piece.type; 

          //Set old square unoccupied
          OSquare.isOccupied = false;
          OSquare.isOccupiedWithBlue = null;
          OSquare.isOccupiedWithMaster = null;

          //Seat adjustments
          if (OSquare.isSeat)
            {
              if (OSquare.isBlueSeat.Value)
                {
                  piece.transform.localPosition += new Vector3(0,-2.4f,0.5f); 
                }
              else
                {
                  piece.transform.localPosition += new Vector3(0,-2f,1.2f); 
                }
            }
          if (Square.isSeat)
            {
              if (Square.isBlueSeat.Value)
                {
                  piece.transform.localPosition += new Vector3(0,2.4f,-0.5f); 
                }
              else
                {
                  piece.transform.localPosition += new Vector3(0,2f,-1.2f);  
                }
            }

          //Blank highlights
          card.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
          piece.GetComponentInChildren<MeshRenderer>().material.shader = Shader.Find("VertexLit");
          foreach (GameObject sqr in GameLoad.highlightedSquares)
            {
              sqr.GetComponentsInChildren<MeshRenderer>(true)[1].enabled = false;
            }
          GameLoad.highlightedSquares.Clear();

          //Card assignment
          Q.assignedTo =  true;
          Q.assignedToBlue = GameController.blueTurn;
          Card.assignedTo = false;
          Card.assignedToBlue = null;

          //Card sprite swapping
          MeshRenderer qR = q.GetComponentInChildren<MeshRenderer>(), cR = card.GetComponentInChildren<MeshRenderer>();
          MeshRenderer[] qRs = q.GetComponentsInChildren<MeshRenderer>(true), cRs = card.GetComponentsInChildren<MeshRenderer>(true);
          qR.gameObject.SetActive(false); cR.gameObject.SetActive(false);
          qRs[GameController.CardNameToInt(Card.nameOfMove)].gameObject.SetActive(true); cRs[GameController.CardNameToInt(Q.nameOfMove)].gameObject.SetActive(true);

          //Check win conditions
          if (GameController.blueTurn)
            {                                                    
              if ((Piece.type && Square.isSeat && !Square.isBlueSeat.Value) || (GameObject.Find("RedP2") == null))
                {                                                   
                  winner = true;
                  SceneManager.LoadScene("WinMenu",LoadSceneMode.Additive); 
                }
            }
          else
            {
              if ((Piece.type && Square.isSeat && Square.isBlueSeat.Value) || (GameObject.Find("BlueP2") == null))
                {
                  winner = false;
                  SceneManager.LoadScene("WinMenu",LoadSceneMode.Additive); 
                }
            }

          //Change turn and blank assignments
          GameController.blueTurn = !GameController.blueTurn;
          GameController.setTurnText();
          GameLoad.card = null; GameLoad.cardSelected = false;
          GameLoad.piece = null; GameLoad.pieceSelected = false;

          //Set camera
          GameController.setCamera();

        }
    } 
    
  public int fPx(Transform t)
    {
      if (!GameController.blueTurn)
        return 4-(Mathf.RoundToInt(t.position.x/10)+2);
      return Mathf.RoundToInt(t.position.x/10)+2;
    }
  public int fPy(Transform t)
    {          
      if (!GameController.blueTurn)
        return 4-jer(t.position.y);
      return jer(t.position.y);
    }

  public void selectTiles(GameObject card, GameObject piece)
    {             
      string str = card.GetComponentInChildren<MeshRenderer>().gameObject.name;   
      WRMVGame.Card Card = WRMVGame.GameController.findCard(str.Substring(0,3)); 
      foreach(WRMVGame.Move move in Card.possibleMoves)
        {
          float x = move.dx*10f+piece.transform.position.x, y = move.dy*5.25f+piece.transform.position.y; 
          if (x >= -20.5 && x <= 20.5 && y >= -10 && y <= 12)
            {
              
              int i = Mathf.RoundToInt(x/10)+2; 
              int j = jer(y);    
              if (!GameController.blueTurn)
                {
                  i = 4 - i;
                  j = 4 - j;
                }                                          
              WRMVGame.Cell cell = WRMVGame.GameController.board[i,j]; 
              if (!cell.isOccupied || (cell.isOccupiedWithBlue.Value && !GameController.blueTurn) || (!(cell.isOccupiedWithBlue.Value) && GameController.blueTurn))
                {
                  GameObject sqr = GameObject.Find("sqr"+i.ToString()+j.ToString());
                  GameLoad.highlightedSquares.Add(sqr);
                }
            }
        }
    }

  private int jer(float y)
    {
      int rY = Mathf.RoundToInt(y);  
      if (rY > 10)
        return 0;
      if (rY > 5)
        return 1;
      if (rY > -1)
        return 2;
      if (rY > -6)
        return 3;
      return 4;
    }  
}
