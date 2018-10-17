using System.Collections.Generic;

namespace WRMVGame
  {
    public class Card
      {
        public string nameOfMove { get; set; }
        public bool specialColour { get; set; }
        public bool assignedTo { get; set; }
        public bool? assignedToBlue { get; set; }
        public List<Move> possibleMoves { get; set; }
        
        public Card() {}
        // specialColour: true = blue, false = red
        // assignedTo: 0 = no one, 1 = blue, 2 = red
        public Card(string nameOfMove, bool specialColour, int assignment, List<Move> possibleMoves)
          {
            this.nameOfMove = nameOfMove;
            this.specialColour = specialColour;
            if (assignment == 0) {
              assignedTo = false;
            } else if (assignment == 1) {
              assignedTo = true;
              assignedToBlue = true;
            } else {
              assignedTo = true;
              assignedToBlue = false;
            }
            this.possibleMoves = possibleMoves;
          }

        public Move findMove(int dx, int dy)
          {
            return possibleMoves.Find(x => (x.dx == dx && x.dy == dy));
          }
        
      }
  }
