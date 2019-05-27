using ToyRobotSimulator.Models.Robot;
using ToyRobotSimulator.Models.Table;
using ToyRobotSimulator.Services.Interfaces;

namespace ToyRobotSimulator.Services.Implementations {

    /// <summary>
    ///  This class is the ISimulationService interface implementation.
    ///  The methods are used to simulate robot interaction on the table.
    /// </summary>
    public class SimulationService : ISimulationService {

        /// <summary>
        /// Places the robot on the table only if the position is valid and set
        /// to the robot the position and the orientation.
        /// </summary>
        /// <param name="robot">Robot object.</param>
        /// <param name="position">Proposed position of the robot.</param>
        /// <param name="orientation">Proposed orientation of the robot.</param>
        public void Place(Robot robot, Position position, OrientationType orientation) {
            if (IsValidPosition(position)) {
                robot.Position = position;
                robot.Orientation = orientation;
            }
        }

        /// <summary>
        ///  Moves the robot forward according his orientation but only if the 
        ///  target position is allowed.
        /// </summary>
        /// <param name="robot">Robot object.</param>
        public void Move(Robot robot) {
            var nextPosition = new Position(robot.Position.XAxis, robot.Position.YAxis);
            switch (robot.Orientation) {
                case OrientationType.SOUTH:
                    nextPosition.YAxis--;
                    break;
                case OrientationType.WEST:
                    nextPosition.XAxis--;
                    break;
                case OrientationType.NORTH:
                    nextPosition.YAxis++;
                    break;
                case OrientationType.EAST:
                    nextPosition.XAxis++;
                    break;
            }
            if (IsValidPosition(nextPosition)) {
                robot.Position = nextPosition;
            }
        }

        /// <summary>
        ///  Rotate the robot according to the direction typed by the user. 
        /// </summary>
        /// <param name="robot">Robot object.</param>
        /// <param name="rotation">Rotation typed by the user.</param>
        public void ExecuteRotation(Robot robot, RotationType rotation) {
            switch (robot.Orientation) {
                case OrientationType.SOUTH:
                    robot.Orientation = rotation.Equals(RotationType.Left) ? OrientationType.EAST : OrientationType.WEST;
                    break;
                case OrientationType.WEST:
                    robot.Orientation = rotation.Equals(RotationType.Left) ? OrientationType.SOUTH : OrientationType.NORTH;
                    break;
                case OrientationType.NORTH:
                    robot.Orientation = rotation.Equals(RotationType.Left) ? OrientationType.WEST : OrientationType.EAST;
                    break;
                case OrientationType.EAST:
                    robot.Orientation = rotation.Equals(RotationType.Left) ? OrientationType.NORTH : OrientationType.SOUTH;
                    break;
            }
        }

        /// <summary>
        ///  Gets the robot report.
        /// </summary>
        /// <param name="robot">Robot object.</param>
        /// <returns>Returns a string with the current robot position and his orientation.</returns>
        public string GetReport(Robot robot) {
            return $"{robot.Position.XAxis},{robot.Position.YAxis},{robot.Orientation}";
        }

        /// <summary>
        /// Check if a position is valid for the robot.
        /// </summary>
        /// <param name="position">Next position.</param>
        /// <returns>Returns true if the position is valid.</returns>
        private bool IsValidPosition(Position position) {
            if ((position.XAxis >= 0 && position.XAxis < Table.Columns) &&
                 position.YAxis >= 0 && position.YAxis < Table.Raws) {
                return true;
            }
            return false;
        }
    }
}
