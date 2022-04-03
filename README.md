# ToyRobot
This is a C# console application developed using Visual Studio Community 2019 for Mac. 

Please clone the repository and open the solution file in Visual Studio installed in your local machine.
Make sure to Build > Clean All then run the codes.  

Unit tests and integration tests in nUnit are also included.

When running the application in terminal or in command line, make sure the commands [MOVE | PLACE | LEFT | RIGHT | EXIT] are CAPITALIZED.

# Example Input and Output:

a)----------------

PLACE 0,0,NORTH

MOVE

REPORT

Output: 0,1,NORTH


b)----------------

PLACE 0,0,NORTH

LEFT

REPORT

Output: 0,0,WEST


c)----------------

PLACE 1,2,EAST

MOVE

MOVE

LEFT

MOVE

REPORT

Output: 3,3,NORTH

# Screenshot
![Screenshot](https://github.com/annavatar17/ToyRobot/blob/main/ToyRobotScreenShot.png)

