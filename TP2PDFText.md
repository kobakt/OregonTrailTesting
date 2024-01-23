# OregonTrailTesting Project

## Link to the testing Repository

https://github.com/kobakt/OregonTrailTesting

## Building the Project

The project is very easy to build. Cloning the repository and opening it in Visual Studio has been enough for our team members to build and run the program and tests.
### Steps
1. Clone the repository. This can be done either through the terminal or through Visual Studio's project wizard.
2. Open the project solution. This can be done by double clicking the solution file or by opening it in Visual Studio.
3. To build: select "Build Solution" from the "Build" menu in Visual Studio.
4. To run: select "Start Debugging" from the "Debug" menu in Visual Studio.
5. To run tests: select "Run All Tests" from the "Test" menu in Visual Studio.

The original project owner also provided these build instructions which can also be found on the repository's readme file:

>## Compilation Instructions
>
>You should be able to run the Cake build script by invoking the bootstrapper with a script tailored to the target platform.
>### Windows
>
>build.bat
>
>If script execution fail due to the execution policy, you might have to tell PowerShell to allow running scripts. You do this by changing the execution policy.
>### Linux/OS X
>
>bash build.sh

## Original Project Repository

https://github.com/Maxwolf/OregonTrail

## Project Summary

### What is the project?
This project is a clone of the the original Oregon Trail console game. You start your journey to the West by following the Oregon Trail. 
You buy supplies, ford rivers, deal with disease all along the way.

### Our experiences so far
One issue we have run into is the lack of interfaces. If we want to use mocks, new interfaces will need to be created. 
So far, the IPerson interface was added to stand-in for the Person class. This was created to test the Vehicle class.

When running the program itself, the program tends to crash after a certain amount of progress in the game. 
This won't affect unit testing, but may limit the amount of console testing we can do. However, It does give us the oppurtunity to try and discover the cause of the crash.

There are a lot of classes in the program, so we will not be able to test them all.
