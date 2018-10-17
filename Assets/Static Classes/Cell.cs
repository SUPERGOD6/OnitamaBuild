namespace WRMVGame
  {
    public class Cell
      {
        public int x { get; set; }
        public int y { get; set; }
        public bool isSeat { get; set; }
        public bool? isBlueSeat { get; set; }
        public bool isOccupied { get; set; }
        public bool? isOccupiedWithBlue { get; set; }
        public bool? isOccupiedWithMaster { get; set; }
        
        public Cell() {}
        // seat: 0 is not a seat, 1 is blue seat, 2 is red seat
        // occupation: 0 is unoccupied, 1 is blue pawn, 2 is blue master, 3 is red pawn, 4 is red master
        public Cell(int x, int y, int seat, int occupation)
          {
            this.x = x;
            this.y = y;
            if (seat == 0) { 
              isSeat = false;
            } else if (seat == 1) {
              isSeat = true;
              isBlueSeat = true;
            } else {
              isSeat = true;
              isBlueSeat = false;
            }
            if (occupation == 0) {
              isOccupied = false;
            } else if (occupation == 1) {
              isOccupied = true;
              isOccupiedWithBlue = true;
              isOccupiedWithMaster = false;
            } else if (occupation == 2) {
              isOccupied = true;
              isOccupiedWithBlue = true;
              isOccupiedWithMaster = true;
            } else if (occupation == 3) {
              isOccupied = true;
              isOccupiedWithBlue = false;
              isOccupiedWithMaster = false;
            } else {
              isOccupied = true;
              isOccupiedWithBlue = false;
              isOccupiedWithMaster = true;
            }
            
          }
      }
  }
