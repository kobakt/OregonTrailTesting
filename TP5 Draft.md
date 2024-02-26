# Intro to OregonTrailDotNet

OregonTrailDotNet is a remake of the original Oregon Trail game coded in C#.
The premise of the game is that you are a group of settlers heading West to Oregon during the 1800s.
Throughout your journey, you will experience many hardships. 
Some hardships may even lead to the death of your entire party.
The game tries to portray the bleak realities of the journey in a fun, gamified way.

It runs in console and the uses the library WolfCurses.
The project started with no tests which creates a great oppurtunity for us.

INSERT PICTURES HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

# Code Coverage

Our code coverage is supplemented with integration tests.

# Regression Testing

# Unit and Integration Testing

# Automated UI and Integration Testing

UI testing was attempted, but as of now has been unsuccessful. More about the problems with UI testing can be found in Lessons Learned.

# Test Plan

## Identifier: OTDN-MTP

## Introduction

OregonTrailDotNet is a simple Oregon Trail clone. As of now, the program has no tests
to ensure its quality. The goal of this test plan is to add some precursory testing
for the purpose of evaluating the quality of the product.
A future test plan may take a more expansive approach to ensure quality, 
if more time can be allocated.

The scope of this test plan is currently limited to precursory unit, integration, and system tests
We plan to test many low-level functions of the program to dtermine the quality of these low-level aspects.
This will include unit and integration tests. As this is precursory, the tests will not be exhaustive and
will not touch every part of the codebase. Adding on to this will be integration tests which expand upon the 
unit tests created.

System tests will also be implemented. These tests may take the form of UI tests, E2E tests, or high-level
integration tests. The tests in tandem with the low-level tests will allow us to perform a sandwich evalutation of the codebase.
This is in line with the goal to test aspects of the program at all levels 
under the limited amoount of time allocated for testing.

## Test Items

The items to be tested wil be broken down into categories based on the types of tests.
### Unit:
Classes to be tested include
* Vehicle
* Person
* Item
* Etc.

### Integration:
Class integrations to to be tested include:
* Vehicle-Person
* Etc.

### System:
As of now, this is planned to be undertaken at the UI/console level.
However, if aspects of testing continue to be a challenge, 
high-level system tests may be undertaken instead.

## Approach

We will be using Visual Studio Enterprise as are IDE for the testing.
Our test framework will be XUnit. For mocking, NSubstitute will be used.
For system testing, FlaUI may be used for UI testing. 
Microsoft Fakes may also be used if necessary.

The progress of the test plan will be measured using code coverage.
As this is precursory testing plan, any improvement in code coverage will be seen as a success.

## Test Deliverables

We plan to deliver complete automated unit, integration, and system tests. 
Additionally, we plan on implementing a regression test script to build and test our code base.

## Planning Risks and Contingincies

### Lack of Personnel Availability

As this is one of many homework assignments for members of out team, 
our team may not always have the availability to work on the project
To deal with this potential obstacle, other members may take on the work of the other team member.
Additionally, there may be the option to scale back on the work needed fro the project. 

### Untestable Code

If code is deemed untestable, measures may be taken to make it more testable.
This may include modifying the code to separate dependencies.
For system tests, there are a number of different strategies that may be undertaken if one fails.
If FlaUI fails, then substituting streams, using Microsoft Fakes, or implementing dependency wrappers may be used instead.

### Tool Failures

If Visual Studio fails, the prject can continue through the use of other IDEs or text editors. Command line could then be used to build and run the program and tests.
If GitHub fails, team members could consider hosting the project on a different service or manually send each other changes.

# Lessons Learned

This project has helped us learn how important testable code is. 
The project does not follow a lot of the SOLID or other OOP design principles.
Instead it has very coupled dependencies. This made it harder to use mocks
and to do console testing.

The program generally uses concrete classes instead of relying on interfaces.
This makes it impossible to unit test most code because you can't make mocks for the dependencies.
This can be solved by modifying the code and implementing your own interfaces, but this
is time consuming and not always straightforward.

Additionally, the program has tight ddependencies to the Console and WolfCurses library.
The console dependency was the initial barrier to UI tetsing. Three attempts were mdae to deal with it.
The first attempt was to modify the code and make a wrapper class that could be mocked. 
The second attempt was to use substitute streams in the console tests. 
The third attempt was to use a shim from Microsoft Fakes. 

All three attempts were able to release the dependency on Console, 
but the dependency on WolfCurses would prevent further progress.
The WolfCurses was especially hard to deal with because the library relies on a console window being open
and many integral parts of the game logic are tightly coupled through inheritance.

This is a great lesson because it teaches us not only about testing, but also about design and implementation details.
Writing code that isn't testable may require modification or large rewrites down the line. 
So, make the code testable from the beginning.
