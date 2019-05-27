namespace ToyRobotSimulator.Models.Robot {

    /// <summary>
    /// This class represent the robot position on the table.
    /// </summary>
    public class Position {
        public int XAxis { get; set; }
        public int YAxis { get; set; }

        public Position(int x, int y) {
            this.XAxis = x;
            this.YAxis = y;
        }
    }
}
