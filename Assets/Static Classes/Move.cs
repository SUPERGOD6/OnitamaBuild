namespace WRMVGame
  {
    public class Move
      {
        public int dx { get; set; }
        public int dy { get; set; }
        
        public Move() {}
        public Move(int dx, int dy)
          {
            this.dx = dx;
            this.dy = dy;
          }
        
      }
  }
