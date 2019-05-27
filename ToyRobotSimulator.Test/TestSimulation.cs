using ToyRobotSimulator.Models.Robot;
using ToyRobotSimulator.Services.Implementations;
using ToyRobotSimulator.Services.Interfaces;
using Xunit;

namespace ToyRobotSimulator.Test {
    public class TestSimulation {

        private ISimulationService simulationService;

        public TestSimulation() {
            simulationService = new SimulationService();
        }

        [Fact]
        public void Place() {
            Robot robot = new Robot();
            Position position = new Position(0, 3);
            simulationService.Place(robot, position, OrientationType.EAST);
            Assert.Equal(0, robot.Position.XAxis);
            Assert.Equal(3, robot.Position.YAxis);
            Assert.Equal(OrientationType.EAST, robot.Orientation);
        }

        [Fact]
        public void Move() {
            Robot robot = new Robot();
            robot.Position = new Position(0, 0);
            robot.Orientation = OrientationType.NORTH;
            simulationService.Move(robot);
            Assert.Equal(0, robot.Position.XAxis);
            Assert.Equal(1, robot.Position.YAxis);
        }

        [Fact]
        public void Rotate() {
            Robot robot = new Robot();
            robot.Position = new Position(0, 0);
            robot.Orientation = OrientationType.NORTH;
            simulationService.ExecuteRotation(robot, RotationType.Left);
            Assert.Equal(OrientationType.WEST, robot.Orientation);
        }

        [Fact]
        public void GetReport() {
            Robot robot = new Robot();
            robot.Position = new Position(2, 3);
            robot.Orientation = OrientationType.SOUTH;
            string report = simulationService.GetReport(robot);
            Assert.Equal("2,3,SOUTH", report);
        }

    }
}