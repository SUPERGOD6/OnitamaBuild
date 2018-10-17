using System.Collections.Generic;

namespace WRMVGame
  {
    public static class DeckCards
      {
        public static List<Card> cards = populateList();
        
        private static List<Card> populateList()
          {
            List<Card> c = new List<Card>();
            c.Add(makeBoar());
            c.Add(makeCobra());
            c.Add(makeCrab());
            c.Add(makeCrane());
            c.Add(makeDragon());
            c.Add(makeEel());
            c.Add(makeElephant());
            c.Add(makeFrog());
            c.Add(makeGoose());
            c.Add(makeHorse());
            c.Add(makeMantis());
            c.Add(makeMonkey());
            c.Add(makeOx());
            c.Add(makeRabbit());
            c.Add(makeRooster());
            c.Add(makeTiger());
            return c;
          }
        
        private static Card makeBoar()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(0,1));
            moves.Add(new Move(-1,0));
            moves.Add(new Move(1,0));
            Card c = new Card("Vaapad",false,0,moves);
            return c;
          }
        private static Card makeCobra()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,0));
            moves.Add(new Move(1,1));
            moves.Add(new Move(1,-1));
            Card c = new Card("Ataru",false,0,moves);
            return c;
          }
        private static Card makeCrab()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-2,0));
            moves.Add(new Move(0,1));
            moves.Add(new Move(2,0));
            Card c = new Card("Dun Moch",true,0,moves);
            return c;
          }
        private static Card makeCrane()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(0,1));
            moves.Add(new Move(1,-1));
            moves.Add(new Move(-1,-1));
            Card c = new Card("Makashi",true,0,moves);
            return c;
          } 
        private static Card makeDragon()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-2,1));
            moves.Add(new Move(2,1));
            moves.Add(new Move(-1,-1));
            moves.Add(new Move(1,-1));
            Card c = new Card("Jar Kai",false,0,moves);
            return c;
          }
        private static Card makeEel()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,1));
            moves.Add(new Move(-1,-1));
            moves.Add(new Move(1,0));
            Card c = new Card("Soresu",true,0,moves);
            return c;
          }
        private static Card makeElephant()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,0));
            moves.Add(new Move(-1,1));
            moves.Add(new Move(1,0));
            moves.Add(new Move(1,1));
            Card c = new Card("Trispzest",false,0,moves);
            return c;
          }
        private static Card makeFrog()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,1));
            moves.Add(new Move(-2,0));
            moves.Add(new Move(1,-1));
            Card c = new Card("Lus-ma",false,0,moves);
            return c;
          }
        private static Card makeGoose()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,0));
            moves.Add(new Move(-1,1));
            moves.Add(new Move(1,0));
            moves.Add(new Move(1,-1));
            Card c = new Card("Ashla",true,0,moves);
            return c;
          }
        private static Card makeHorse()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,0));
            moves.Add(new Move(0,1));
            moves.Add(new Move(0,-1));
            Card c = new Card("Niman",false,0,moves);
            return c;
          }
        private static Card makeMantis()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,1));
            moves.Add(new Move(1,1));
            moves.Add(new Move(0,-1));
            Card c = new Card("Shii-Cho",false,0,moves);
            return c;
          }
        private static Card makeMonkey()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,-1));
            moves.Add(new Move(-1,1));
            moves.Add(new Move(1,-1));
            moves.Add(new Move(1,1));
            Card c = new Card("Trakata",true,0,moves);
            return c;
          }
        private static Card makeOx()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(0,1));
            moves.Add(new Move(0,-1));
            moves.Add(new Move(1,0));
            Card c = new Card("Djem So",true,0,moves);
            return c;
          }
        private static Card makeRabbit()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,-1));
            moves.Add(new Move(1,1));
            moves.Add(new Move(2,0));
            Card c = new Card("Sokan",true,0,moves);
            return c;
          }
        private static Card makeRooster()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(-1,0));
            moves.Add(new Move(-1,-1));
            moves.Add(new Move(1,0));
            moves.Add(new Move(1,1));
            Card c = new Card("Bogan",false,0,moves);
            return c;
          }
        private static Card makeTiger()
          {
            List<Move> moves = new List<Move>();
            moves.Add(new Move(0,2));
            moves.Add(new Move(0,-1));   
            Card c = new Card("Form Zero",true,0,moves);
            return c;
          }
        
      }
  }
