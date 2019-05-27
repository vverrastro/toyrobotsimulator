using System;
using ToyRobotSimulator.Common;
using ToyRobotSimulator.Models.Command;
using ToyRobotSimulator.Models.Robot;
using ToyRobotSimulator.Services.Interfaces;

namespace ToyRobotSimulator.Services.Implementations {
    /// <summary>
    ///  This class is the ICommandService interface implementation.
    ///  The two methods are used to parse the user input string for
    ///  get a corret command for the robot.
    /// </summary>
    public class CommandService : ICommandService {
        
        /// <summary>
        ///  Gets the corret command from the input string.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>Returns a valid command type (MOVE, LEFT, RIGHT, REPORT) after parsing.</returns>
        public CommandType ParseCommand(string input) {
            CommandType command;
            if (Enum.TryParse(input.Split(" ").GetValue(0).ToString(), out command) &&
                !int.TryParse(input.Split(" ").GetValue(0).ToString(), out int checkCommand)) {
                return command;
            } else {
                throw new Exception(Errors.WRONG_COMMAND);
            }
        }

        /// <summary>
        /// Gets the correct PLACE command typa from the input string.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>Returns a PlaceCommand object composed by a position and an orientation.</returns>
        public PlaceCommand ParsePlaceCommand(string input) {
            PlaceCommand placeCommand = new PlaceCommand();
            if (input.Split(" ").Length == Constants.PlaceCommandSize) {
                string inputPlace = input.Split(" ").GetValue(1).ToString();
                if (inputPlace.Split(",").Length == Constants.PlaceCommandParameterSize &&
                    !int.TryParse(inputPlace.Split(",").GetValue(2).ToString(), out int checkCommand)) {
                    string[] parametersInputPlace = inputPlace.Split(",");
                    placeCommand.Position = new Position(
                            Convert.ToInt32(parametersInputPlace.GetValue(0)),
                            Convert.ToInt32(parametersInputPlace.GetValue(1))
                        );

                    OrientationType orientation;

                    if (Enum.TryParse(parametersInputPlace.GetValue(2).ToString(), out orientation)) {
                        placeCommand.Orientation = orientation;
                    } else {
                        throw new Exception(Errors.WRONG_PLACE_ORIENTATION);
                    }
                } else {
                    throw new Exception(Errors.WRONG_PLACE_FORMAT);
                }
            } else {
                throw new Exception(Errors.WRONG_PLACE_FORMAT);
            }
            return placeCommand;
        }
    }
}