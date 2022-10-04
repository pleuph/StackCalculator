# StackCalculator

## Purpose
Make a simple stack calculator, using reverse polish notation, in Unity. Must be able to receive an input and give an output. Having a polished UI is not important. Architecture, error handling etc. should be well considered. 

### Acceptance criteria
- Make a simple stack calculator in unity 
- Support most basic operations +, -, *, /
- Should be able to run on a mobile device (iOS, Android)
- At every 10th calculation, the result is not to be returned, but instead an API call must be made to your favourite online random generator (e.g. https://qrng.anu.edu.au/API/api-demo.php) and a random number from this must be returned.

## Observations and challenges
- I have no experience with Unity
- How do I get Unity?
- What tools are used for Unity development? (Visual Studio?)
- How to get started with a UI app and deploy to device?
- How to manage lifecycle, basic architecture, state? (Last AC requires state)
- I am not experienced in algorithmic operations
- I do not know the definitions of "stack calculatur" and "reverse polish notation"
- Sounds like something that already exists. Use a packaged library?
- Unit testing considerations - external package vs. self-coded logic

## Immediate tasks
- Get Unity and tools
  - Downloaded Unity from https://unity.com/download
  - Created a Unity account
  - Installed Unity Editor via Unity Hub
  - Installed tools for Unity with Visual Studio Installer
- Research stack calculator and reverse polish notation
  - First hit on google seems to explain it: https://stevenpcurtis.medium.com/evaluate-reverse-polish-notation-using-a-stack-7c618c9f80c0

## Next steps
Explore creating a 2D app in VS and UE.
- VS Tools for Unity does not include any project templates or UI tools, seems to be mainly for code editing and debugging
- VS could be useful for writing the logic code and unit tests
- Downloaded 2D Mobile template for UE and created project
  - Created initial UI with label, input box, button and output text field
  - Threw error at runtime - I'm not able to figure out why
  - Not immediately obvious how to connect UI elements with code
  - Learning resources appear to be very time consuming for getting started
  
**Notes:** Shift focus to implementing logic and revisit app/UI later, if there's time.

## Implement logic
- Create a solution with logic and test libraries
- Write tests for each of the main operations and one that uses all four
  - As input contains both number and operators in a string, start by only supporting single-digit integer operands
- Implement the four operations
  - Googling for existing solutions show that many exist. However, it also seems pretty simple to make from scratch
  - When we start handling state, the "Calculate" method can no longer be static
  - Output of divisions can be non-integer values, which will should be handled in some way - for now, accept rounding
  - Input should be scrubbed for any disallowed characters
  - Invalid input (or other errors) should be handled with an error message
- (Skipped) Write test for "10th result is random" rule
- (Skipped) Implement "10th result is random" rule

**Notes:** Further research into the purpose of RPN and questions raised during development raised doubts about what the most meaningful implementation would be. Shift focus to new implementation.

## Implement new solution
- Create a stateful calculator using a stack for storing values
- Add call to external number generator for "10th result is random" rule.
- Write meaningful tests for various scenarios
- Create mockup of UI in Unity

## Conclusions
I am unclear on both the technical requirements and the usage scenario for the output of the task. Not having time to further refine the task before working on it, I ended up focusing on creating two distinct solutions for the implementation of the core logic. Both have a fairly high degree of code coverage in unit tests, and how they work can be demonstrated through those.

### Solution 1
The StackCalculatorService has the ability to take an RPN expression as a string and return the calculated result (or an error) as a string. Features:
- Is limited to single-digit integers in the input expression
- Performs calculations using integers, meaning any final or intermediate results are rounded to the nearest integer
- Can potentially handle very long expressions - however, the capaity of the Stack may need configuration
- Has input scrubbing that automatically removes anything that is not an int or an allowed operator
- Has exception handling - however, all exceptions are considered to be caused by invalid input
- Is stateless and does not fulfill the "10th result is random" requirement

If this approach is close to the desired solution in terms of input and output, it could be improved upon in several ways:
- Can be made stateful and have the "10th result is random" logic added
- Can be upgraded to perform calculations using doubles
- Can be upgraded to accept expressions containing multidigit integers and floating point numbers
  - Would require a separator character, fx. spaces: "12,5 5,8 -"
  - I have not come across what, if any, the standard is for this in RPN

### Solution 2
The StatefulStackCalculator has the ability to take in numbers as doubles and store them on a stack. Four different operations can be applied, popping the top 2 numbers from the stack and returning the result.

Features:
- Supports a practically limitless number of operations
- Numbers (as doubles) can be pushed to the internal stack via the Enter method
- Any of the four operations can be performed once there are at least 2 numbers on the stack
- Any operation pops the last two numbers from the stack, the result is not pushed to the stack
- If less than 2 numbers are on the stack when an operation is attempted, the stack is not changed and 0 is returned
- Every 10th operation returns a non-zero random number, which is a combination of a dotnet random multiplied with an in from: randomnumberapi.com
- Any errors in external calls fail silently and a fallback dotnet random int is used in stead

If this approach is close to the desired solution in terms of input and output, it could be improved upon in several ways:
- Initial stack size can be configured to best support the expected number of operations
- Depending on the required UI, add input scrubbing/validation, handling of single-digit button input etc. 
- Depending on requirements and standards for stack calculators and RPN, the workflow could be improved:
  - Allow operations to accept numbers, thereby skipping an Enter (and stack push)
  - Push result of operation back onto the stack to allow further operations, thereby possibly skipping an Enter

### Unity projects
I Was unable to create working prototypes in Unity. I used the "2D mobile app" template and was able to add UI elements to the screen, but was not able to go beyond that. I ended up creating UI mockups for both solutions, shown in screenshots.

Being completely new to Unity, I encountered the following challenges:
- Encountered errors after adding UI elements
- Was unable to push Unity code to GitHub because some files were too big
- How to connect UI elements with code was not readily apparent to me
- Project structure and number of files (7k+) is unfamiliar and hard to grasp
- Although good learning resources seem to exist, I was not able to find a usable quickstart guide for this type of task
- Because of the above, I did not research how to deploy apps to devices
