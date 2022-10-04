# StackCalculator

## Purpose
Make a simple stack calculator, using reverse polish notation, in Unity. Must be able to receive an input and give an output. Having a polished UI is not important. Architecture, error handling etc. sould be well considered. 

### Acceptance criteria
- Make a simple stack calculator in unity 
- Support most basic operations +, -, *, /
- Should be able to run on a mobile device (iOS, Android)
- At every 10th calculation, the result is not to be returned, but instead an API call must be made to your favourite online random generator (e.g. https://qrng.anu.edu.au/API/api-demo.php) and a random number from this must be returned.

## Observations and challenges
- Dev has no experience with Unity
- How to get Unity?
- What tools are used for Unity development? (Visual Studio?)
- How to get started with a UI app and deploy to device?
- How to manage lifecycle, basic architecture, state? (Last AC requires state)
- Dev not experienced in algorithmic operations
- Definition of "stack calculatur" and "reverse polish notation"?
- Sounds like something that already exists. Use a packaged library?
- Unit testing considerations - external lib vs. self-built

## Immediate tasks
- Get Unity and tools
  - Downloaded Unity from https://unity.com/download
  - Created a Unity account
  - Installed Unity Editor via Unity Hub
  - Installed tools for Unity with Visual Studio Installer
- Research stack calculator and reverse polish notation
  - First hit on google explains it well: https://stevenpcurtis.medium.com/evaluate-reverse-polish-notation-using-a-stack-7c618c9f80c0

## Next steps
- Explore creating a 2D app in VS and UE
  - VS Tools for Unity does not include any project templates or UI tools, is mainly for code editing and debugging
  - VS could be useful for writing the logic code and unit tests
  - Downloaded 2D Mobile template for UE and created project
    - Created initial UI with label, input box, button and output text field
    - Threw error at runtime - dev unable to figure out why
    - Not immediately obvious to dev how to connect UI elements with code
    - Learning resources appear to be very time consuming for getting started
  
**Notes:** Shift focus to implementing logic and revisit app/UI later.

## Implement logic
- Create a solution with logic and test libraries
- Write tests for each of the main operations and one that uses all four
  - As input contains both number and operators in a string, it is simplest to only support integers in the input
- Implement the four operations
  - Googling for existing solutions show that many exist. However, it also seems pretty simple to make from scratch
  - As we know we will need to handle state, the "Calculate" method cannot be static
  - Output of divisions can be non-integer values, which will need to be handled in some way
  - Input should be scrubbed for any non-allowed characters
  - Invalid input should be handled with error message
- (Skipped) Write test for "10th result is random" rule
- (Skipped) Implement "10th result is random" rule

**Notes:** Further research into the purpose of RPN and questions raised during development raised doubts about what the most meaningful implementation would be. Shift focus to new implementation.

## Implement new solution
- Create a stateful calculator using a stack for storing values
- Add call to external number generator for "10th result is random" rule.
- Write meaningful tests for various scenarios
- Create mockup of UI in Unity

## Conclusions

### Solution 1

### Solution 2

### Unity projects
I Was unable to create working prototypes in Unity. I used the "2D mobile app" template and was able to add UI elements to the screen, but was not able to go beyond that. I ended up creating UI mockups for both solutions, shown in screenshots.

Being completely new to Unity, I encountered the following challenges:
- Encountered errors after adding UI elements
- Was unable to push Unity code to GitHub because some files were too big
- How to connect UI elements with code was not readily apparent to me
- Project structure and number files (7k+) is unfamiliar and hard to grasp
- Although good learning resources seem to exist, I was not able to find a usable quickstart guide for this type of task
- Because of the above, I did not research how to deploy apps to devices
