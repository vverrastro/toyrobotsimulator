namespace ToyRobotSimulator.Common {

    /// <summary>
    /// This class contains the constants used in the code.
    /// </summary>
    public static class Constants {

        public static string CLOSE_APPLICATION = "CLOSE";
        public static int PlaceCommandSize = 2;
        public static int PlaceCommandParameterSize = 3;

        public static string WELCOME = @"
+------------------------------------------------------------------------+
                      Welcome to Toy Robot Simulator
+------------------------------------------------------------------------+
                              Vito Verrastro - verrastro.vito90@gmail.com

 - The application is a simulation of a toy robot moving on a square 
   tabletop, of dimensions 5 units x 5 units.

 - Command list:
    PLACE X,Y,ORIENTATION: will put the toy robot on the table in position 
        X,Y and orientation (NORTH, SOUTH, WEST, EAST).
    MOVE: will move the toy robot one unit forward in the direction it is 
        currently facing.
    LEFT: will rotate the robot 90 degrees to the left without changing the 
        position of the robot.
    RIGHT: will rotate the robot 90 degrees to the right without changing 
        the position of the robot.
    REPORT: will announce the X,Y and ORIENTATION of the robot.
    CLOSE: close the application.
        ";

    }
}