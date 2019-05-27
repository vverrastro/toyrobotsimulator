namespace ToyRobotSimulator.Models.Robot {

    /// <summary>
    /// This class represent the robot with his position on the table and his orientation.
    /// </summary>
    public class Robot {
        public Position Position { get; set; }
        public OrientationType Orientation { get; set; }
    }
}