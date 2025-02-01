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
        private void OnSwitchColor(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;

            if (!isToggled)
            {
                SetDarkmodeTheme();
            }
            else
            {
                SetRainbowTheme();
            }
        }
        private void SetRainbowTheme()
        {
            //Set as default theme as xaml is
            // Use the same color values from XAML
            Display.BackgroundColor = Color.FromRgba("#A1C3E3");  // Color for display background
            Display.TextColor = Color.FromRgba("#FFFFFF");  // Text color for display

            // Set the frame background for the dark theme
            CalculatorFrame.BackgroundColor = Color.FromRgba("#22CB29");  // Frame background color

            // Set button background colors for dark theme
            SetButtonsTheme(Color.FromRgba("#F3A53F"), //b1
                            Color.FromRgba("#EEDD38"), //b2
                            Color.FromRgba("#A6E72D"), //b3
                            Color.FromRgba("#40EED0"), //b4
                            Color.FromRgba("#48C1EE"), //b5
                            Color.FromRgba("#4385EE"), //b6
                            Color.FromRgba("#9F69E6"), //b7
                            Color.FromRgba("#E372E7"), //b8
                            Color.FromRgba("#DB53B5"), //b9
                            Color.FromRgba("#E62D5C"), //b0
                            Color.FromRgba("#53E74F"), //bAdd
                            Color.FromRgba("#2E66DA"), //bSub
                            Color.FromRgba("#E635BA"), //bMult
                            Color.FromRgba("#EA0C0C"), //bDiv
                            Color.FromRgba("#E25682"), //bDot
                            Color.FromRgba("#D88D0E"), //bRes
                            Color.FromRgba("#D82642")); //bC 
        }

        private void SetDarkmodeTheme()
        {
            Display.BackgroundColor = Color.FromRgba("#FFBEABAB");
            Display.TextColor = Color.FromRgba("#000000");

            // Set the frame background for the dark theme
            CalculatorFrame.BackgroundColor = Color.FromRgba("#FF413D3D");

            // Set button background colors for dark theme
            SetButtonsTheme(Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"),
                Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"),
                Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"),
                Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"), Color.FromRgba("#F3A53F"),
                Color.FromRgba("#F3A53F"));

        }
        private void SetButtonsTheme(Color btn1C, Color btn2C, Color btn3C, Color btn4C, 
            Color btn5C, Color btn6C, Color btn7C, Color btn8C,
            Color btn9C, Color btn0C, Color btnAddC, Color btnSubC,
            Color btnMultC, Color btnDivC, Color btnDotC, Color btnResC, Color btnCC)
        {
            btn1.BackgroundColor = btn1C;
            btn2.BackgroundColor = btn2C;
            btn3.BackgroundColor = btn3C;
            btn4.BackgroundColor = btn4C;
            btn5.BackgroundColor = btn5C;
            btn6.BackgroundColor = btn6C;
            btn7.BackgroundColor = btn7C;
            btn8.BackgroundColor = btn8C;
            btn9.BackgroundColor = btn9C;
            btn0.BackgroundColor = btn0C;
            btnAdd.BackgroundColor = btnAddC;
            btnSub.BackgroundColor = btnSubC;
            btnMult.BackgroundColor = btnMultC;
            btnDiv.BackgroundColor = btnDivC;
            btnDot.BackgroundColor = btnDotC;
            btnRes.BackgroundColor = btnResC;
            btnC.BackgroundColor = btnCC;

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


