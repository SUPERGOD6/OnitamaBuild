using System;
using System.Collections.Generic;

namespace WRMVGame
  {
    public static class GameController
      {
        public static List<Card> deck { get; set; }
        public static Cell[,] board { get; set; }
        public static List<Piece> pieces { get; set; }

        public static List<Card> cardsInPlay { get; set; }

        public static bool? blueFirst;    

        public static Card findCard(string name)
          {
            foreach(Card c in cardsInPlay)
              {
                if (c.nameOfMove.Contains(name))
                  return c;
              }
            return null;
          }
        public static Piece findPiece(int x, int y)
          {
            foreach(Piece p in pieces)
              {
                if (!p.captured && p.x == x && p.y == y)
                  return p;
              }
            return null;
          }
        public static Card findUnassignedCard()
          {
            foreach(Card c in cardsInPlay)
              {
                if (!c.assignedTo)
                  return c;
              }
            return null;
          }
        
        public static void createGame()
          {
            makeDeck(); 
            makePieces();
            makeBoard();
          }
        public static void beginGame()
          {
            selectCardsToPlayWith();
          }
        
        private static void makeDeck()
          {
            deck = DeckCards.cards;
          }
        private static void makePieces()
          {
            pieces = new List<Piece>();
            for (int i = 0; i < 5; i++)
              {                                                               
                pieces.Add(new Piece(i,4,pieceTypeInit(i),true,false));
                pieces.Add(new Piece(i,0,pieceTypeInit(i),false,false));
              }
          }
        private static void makeBoard()
          {
            board = new Cell[5,5];
            for (int i = 0; i < 5; i++)
              {
                for (int j = 0; j < 5; j++)
                  {                                                                              
                    board[i,j] = new Cell(i,j,seatInit(i,j),occupationInit(i,j));
                  }
              }
          }
        private static void selectCardsToPlayWith()
        {
            cardsInPlay = new List<Card>();
            List<Card> temp = new List<Card>();
            foreach (Card c in deck)
              {
                temp.Add(c);
              }
            Random r = new Random();
            for (int i = 0; i < 5; i++)
              {
                int a = r.Next(0,temp.Count);
                if (i == 0 || i == 2)
                  {
                    temp[a].assignedTo = true;
                    temp[a].assignedToBlue = true;
                  }
                if (i == 1 || i == 3)
                  {
                    temp[a].assignedTo = true;
                    temp[a].assignedToBlue = false;
                  }
                if (i == 4)
                  {
                    blueFirst = temp[a].specialColour;
                  }
                cardsInPlay.Add(temp[a]);
                temp.Remove(temp[a]);
              }
          }
        
        private static bool pieceTypeInit(int x)
          {                    
            return (x == 2);
          }
        private static int seatInit(int x, int y)
          {            
            if (x == 2) {
              if (y == 4) {
                return 1;
              }
              if (y == 0) {
                return 2;
              }
              return 0;
            }
            return 0;
          }
        private static int occupationInit(int x, int y)
          {          
            if (y == 0 || y == 4) {
              if (y == 4) {
                if (x == 2) {
                  return 2;
                }
                return 1;
              }
              if (x == 2) { 
                return 4;
              }
              return 3;
            }
            return 0;
          }

        public static void Each<T>(IEnumerable<T> items, Action<T> action)
          {
            foreach (var item in items)
              action(item);
          }

    }
  }
