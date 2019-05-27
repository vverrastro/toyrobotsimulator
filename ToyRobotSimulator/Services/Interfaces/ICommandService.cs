using ToyRobotSimulator.Models.Command;

namespace ToyRobotSimulator.Services.Interfaces {

    /// <summary>
    ///  This class is the command service interface.
    /// </summary>
    public interface ICommandService {

        /// <summary>
        /// Gets a valid command for the robot.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>Return a command type.</returns>
        CommandType ParseCommand(string input);

        /// <summary>
        ///  Gets a position and orientation for the robot placement.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>Returns a PLACE command.</returns>
        PlaceCommand ParsePlaceCommand(string input);

    }
}