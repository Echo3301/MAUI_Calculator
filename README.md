# MAUI_Calculator
MAUICalculator README
Overview

This project is a simple calculator built using .NET MAUI (Multi-platform App UI) and C#. The application allows users to perform basic arithmetic operations like addition, subtraction, multiplication, and division. The code includes features for handling numeric input, operators, and calculations. Additionally, the project lays the foundation for future improvements, such as customizing the look and feel of the calculator, adding zoom functionality, and applying a frame around the calculator.
Features

    Basic arithmetic operations: +, -, *, /
    Clear (C) button to reset the calculation
    Displays results after performing calculations
    Simple and user-friendly interface

Planned Future Features

    Ability for users to customize the look of the calculator
    Option to adjust the calculator’s zoom level
    Add a frame around the calculator to enhance the user interface

Code Breakdown

The calculator's core functionality is implemented in the MainPage.xaml.cs file and the user interface is defined in the MainPage.xaml file. Here's a summary of key components:
Variables

    _currentInput: Holds the current input string (numbers or operators).
    _previousValue: Stores the previous value used in the calculation (for operations like addition, subtraction, etc.).
    _currentOperator: Holds the current operator selected by the user (e.g., +, -, *, /).
    _isNewCalculation: Flag to detect whether a new calculation is being started (after an operation is completed).

Methods

    NumEntry_Clicked(): Handles number button clicks and appends the number to the current input.
    OperatorEntry_Clicked(): Handles operator button clicks and sets the operator for the calculation. If the "C" button is pressed, the calculation is cleared.
    ClearCalculator(): Resets all variables and the display to start a fresh calculation.
    CalculateWhenClicked(): Executes the selected operation when the equals (=) button is clicked and displays the result.

User Interface (MainPage.xaml)

The user interface is built using a grid layout to arrange buttons for numbers, operators, and the display.

    Entry: A read-only text input field to display the current calculation.
    Button: Each number and operator has its own button. The buttons are assigned different background colors to make the calculator visually appealing.

Event Handlers

    Clicked event handlers are used to associate button clicks with their corresponding actions such as appending numbers or operators, clearing the display, and performing calculations.

Future Development

In the near future, additional features will be added, such as:

    Customizable UI: Users will be able to change the appearance of the calculator (e.g., switch between light and dark modes, customize button styles, etc.).
    Zoom Functionality: Users will be able to zoom in and out to resize the calculator interface.
    Framing the Calculator: Adding a frame around the entire calculator UI for a more polished look.

Setup Instructions

    Clone or download the repository.
    Open the solution file (MAUICalculator.sln) in Visual Studio or another C# IDE that supports .NET MAUI.
    Build and run the project on your desired platform (iOS, Android, Windows, or macOS).

License

This project is open source. Feel free to fork, contribute, or modify the code as needed for personal or professional use.

If you have any questions or feedback, feel free to reach out or open an issue on the repository. 
