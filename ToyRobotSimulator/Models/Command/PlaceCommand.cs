using ToyRobotSimulator.Models.Robot;

namespace ToyRobotSimulator.Models.Command {

    /// <summary>
    /// This class represent the PLACE command.
    /// </summary>
    public class PlaceCommand {       
        public Position Position { get; set; }
        public OrientationType Orientation { get; set; }
    }
}