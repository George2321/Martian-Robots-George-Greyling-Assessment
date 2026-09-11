# Martian Planet Adventures

## Description

.NET 10 console application.

I used the strategy pattern and the interface segregation principle to make the code more maintainable and scalable.

The strategy pattern allows different behaviours to be implemented and swapped without changing the robot domain code. Interface segregation ensures that classes only implement the contracts they need, reducing unnecessary dependencies.

## Getting Started

To add a new movement, add a class that implements `IRobotActionStrategy`.

### Dependencies

- .NET 10
- Windows 10

### Installing

Clone the repository and open the solution in Visual Studio or Visual Studio Code, then run the console application.

### Executing program

Enter movement commands for the robots.

## Help

Use only the supported `L`, `R`, and `F` movement instructions.

## Authors
George Greyling

## Version History
0


## License
None


## Acknowledgments
Minimal AI was intentionally used to showcase my design decisions, coding, and problem-solving skills.
AI was used for wiring boilerplate code, adding unit tests, answering focused questions, and creating the ASCII art shown when the console application starts.

# Additional Notes

I did not finish the assignment within the allotted three hours; I spent approximately three and a half hours on it.

With more time, I would have:

- Completed the movement service by calculating orientation and coordinates and updating each robot's internal state.
- Added helpers to track where robots fell off the planet grid.
- Reported each robot's position and orientation after its movement command.
- Added more unit tests.
- Reviewed and refactored the code further for maintainability and clarity.
