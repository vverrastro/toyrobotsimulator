using System;
using ToyRobotSimulator.Common;
using ToyRobotSimulator.Controllers;

namespace ToyRobotSimulator {
    class Program {
        static void Main(string[] args) {
            SimulationController controller = new SimulationController();
            Console.WriteLine(Constants.WELCOME);

            bool execution = true;

            while (execution) {
                Console.Write("Command: ");
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) {
                    continue;
                } else {
                    if (input.Equals(Constants.CLOSE_APPLICATION)) {
                        execution = false;
                    } else {
                        controller.ExecuteCommand(input);
                    }
                }
            }
        }
    }
}
