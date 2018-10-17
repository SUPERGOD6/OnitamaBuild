namespace WRMVGame
  {
    public class Piece
      {
        public int x { get; set; }
        public int y { get; set; }
        public bool type { get; set; }
        public bool colour { get; set; }
        public bool captured { get; set; }
        
        public Piece() {}
        // type: true = master, false = pawn
        // colour: true = blue, false = red
        public Piece(int x, int y, bool type, bool colour, bool captured)
          {
            this.x = x;
            this.y = y;
            this.type = type;
            this.colour = colour;
            this.captured = captured;
          }
      }
  }
