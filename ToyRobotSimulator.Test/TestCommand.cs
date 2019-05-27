using System;
using ToyRobotSimulator.Common;
using ToyRobotSimulator.Models.Command;
using ToyRobotSimulator.Models.Robot;
using ToyRobotSimulator.Services.Implementations;
using ToyRobotSimulator.Services.Interfaces;
using Xunit;

namespace ToyRobotSimulator.Test {
    public class TestCommand {

        private ICommandService commandService;

        public TestCommand() {
            commandService = new CommandService();
        }

        [Fact]
        public void ParseValidCommand() {
            CommandType command = commandService.ParseCommand("MOVE");
            Assert.Equal(CommandType.MOVE, command);
        }

        [Fact]
        public void ParseInvalidCommand() {
            var exception = Assert.Throws<Exception>( delegate { commandService.ParseCommand("STOP"); });
            Assert.Equal(Errors.WRONG_COMMAND, exception.Message);
        }

        [Fact]
        public void ParseValidPlaceCommand() {
            PlaceCommand placeCommand = new PlaceCommand();
            placeCommand.Position = new Position(2,4);
            placeCommand.Orientation = OrientationType.WEST;
            PlaceCommand result = commandService.ParsePlaceCommand("PLACE 2,4,WEST");
            Assert.Equal(placeCommand.Orientation, result.Orientation);
            Assert.Equal(placeCommand.Position.XAxis, result.Position.XAxis);
            Assert.Equal(placeCommand.Position.YAxis, result.Position.YAxis);
        }

        [Fact]
        public void ParseInvalidPlaceCommand() {
            var exception = Assert.Throws<Exception>(delegate { commandService.ParsePlaceCommand("PLACE 0,0,SOUTH,4"); });
            Assert.Equal(Errors.WRONG_PLACE_FORMAT, exception.Message);
        }

    }
}
