using System;
using ToyRobotSimulator.Models.Command;
using ToyRobotSimulator.Models.Robot;
using ToyRobotSimulator.Services.Implementations;
using ToyRobotSimulator.Services.Interfaces;

namespace ToyRobotSimulator.Controllers {

    /// <summary>
    ///  This class create the robot. 
    ///  Then the class uses the command service to parse the user input string 
    ///  and then if the command is valid the class uses the simulation service
    ///  to execute an operation on the robot. 
    /// </summary>
    public class SimulationController {

        private Robot _robot;
        private ISimulationService _simulationService;
        private ICommandService _commandService;

        public SimulationController() {
            _robot = new Robot();
            _simulationService = new SimulationService();
            _commandService = new CommandService();
        }

        /// <summary>
        ///  Execute the user command after parsing and only if it is valid.
        ///  If the command is valid the status of the robot will change.
        /// </summary>
        /// <param name="input">User input string</param>
        public void ExecuteCommand(string input) {
            try {
                CommandType command = _commandService.ParseCommand(input);
                if (_robot.Position == null && !command.Equals(CommandType.PLACE)) {
                    return;
                }

                switch (command) {
                    case CommandType.PLACE:
                        PlaceCommand placeCommand = _commandService.ParsePlaceCommand(input);
                        _simulationService.Place(_robot, placeCommand.Position, placeCommand.Orientation);
                        break;
                    case CommandType.MOVE:
                        _simulationService.Move(_robot);
                        break;
                    case CommandType.LEFT:
                        _simulationService.ExecuteRotation(_robot, RotationType.Left);
                        break;
                    case CommandType.RIGHT:
                        _simulationService.ExecuteRotation(_robot, RotationType.Right);
                        break;
                    case CommandType.REPORT:
                        Console.WriteLine(_simulationService.GetReport(_robot));
                        break;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
