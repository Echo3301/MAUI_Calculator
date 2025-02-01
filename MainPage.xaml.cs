    using System;
    using Microsoft.Maui.Controls;
namespace MAUICalculator
{

 
        public partial class MainPage : ContentPage
        {
            private string _currentInput = "";    //Current input string
            private double _previousValue = 0;    //Previous value for calculations
            private string _currentOperator = ""; //Current operator for calculation
            private bool _isNewCalculation = true; //To detect if we are starting fresh

            public MainPage()
            {
                InitializeComponent();
            }

            //For number buttons
            private void NumEntry_Clicked(object sender, EventArgs e)
            {
                var button = sender as Button;
                if (button != null)
                {

                    if (_isNewCalculation)
                    {
                        Display.Text = button.Text;
                        _isNewCalculation = false;
                    }
                    else
                    {
                        Display.Text += button.Text;
                    }
                    _currentInput += button.Text;
                }
            }

            //For operator buttons (+, -, *, /, C)
            private void OperatorEntry_Clicked(object sender, EventArgs e)
            {
                var button = sender as Button;
                if (button != null)
                {
                    if (button.Text == "C") //Restart calculation
                    {
                        ClearCalculator();
                    }
                    if (_currentInput != ""&& _currentInput != "C")
                    {
                            Display.Text += " " + button.Text + " ";
                            _previousValue = double.Parse(_currentInput);
                            _currentOperator = button.Text;
                            _currentInput = "";
                    }
                }
            }
        private void ClearCalculator()
        {
            _currentInput = "";
            _previousValue = 0;
            _currentOperator = "";
            _isNewCalculation = true;
            Display.Text = ""; 
        }
            private void Slider_ScaleValue(object sender, ValueChangedEventArgs e)
        {
            double scale = e.NewValue;
            CalculatorFrame.Scale = scale;
        }
        //For the equals button to perform the calculation
        private void CalculateWhenClicked(object sender, EventArgs e)
            {
                if (_currentInput != "" && _previousValue != 0)
                {
                    double currentValue = double.Parse(_currentInput);
                    double result = 0;

                    switch (_currentOperator)
                    {
                        case "+":
                            result = _previousValue + currentValue;
                            break;
                        case "-":
                            result = _previousValue - currentValue;
                            break;
                        case "*":
                            result = _previousValue * currentValue;
                            break;
                        case "/":
                            if (currentValue != 0)
                                result = _previousValue / currentValue;
                            else
                                Display.Text = "Error";
                            break;
                    }

                    Display.Text = result.ToString();
                    _previousValue = result;  //Store result for further calculations
                    _currentInput = result.ToString();
                    _currentOperator = "";  //Reset operator
                    _isNewCalculation = true;
                }
            }
        }
}


