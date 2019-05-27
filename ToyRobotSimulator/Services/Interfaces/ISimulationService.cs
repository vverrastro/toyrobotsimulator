using ToyRobotSimulator.Models.Robot;

namespace ToyRobotSimulator.Services.Interfaces {

    /// <summary>
    ///  This class is the simulation service interface.
    /// </summary>
    public interface ISimulationService {

        /// <summary>
        ///  Places the robot on the table.
        /// </summary>
        /// <param name="robot">Robot object.</param>
        /// <param name="position">Robot position.</param>
        /// <param name="orientation">Robot orientation.</param>
        void Place(Robot robot, Position position, OrientationType orientation);

        /// <summary>
        ///  Moves the robot forward.
        /// </summary>
        /// <param name="robot">Robot object.</param>
        void Move(Robot robot);

        /// <summary>
        /// Rotate the robot. 
        /// </summary>
        /// <param name="robot">Robot object.</param>
        /// <param name="rotation">Rotation type (left or right).</param>
        void ExecuteRotation(Robot robot, RotationType rotation);

        /// <summary>
        /// Gets the robot status.
        /// </summary>
        /// <param name="robot">Robot object.</param>
        /// <returns>Returns a formatted string with robot status.</returns>
        string GetReport(Robot robot);
        
    }
}
