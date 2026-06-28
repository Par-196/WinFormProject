using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool mainScreenIsClear;
        private double firstNumber;
        private double secondNumber;
        private char action = ' ';
        private bool calculationCompleted;
        private bool wasItDividedByOne;
        private bool percentWasCalculated;

        public Calculator()
        {
            InitializeComponent();
            main_screen.Text = "0";
        }

        private void number_zero_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 0;
        }

        private void number_one_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 1; 
        }

        private void number_two_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 2;
        }

        private void number_three_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 3;
        }

        private void number_four_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 4;
        }

        private void number_five_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 5;
        }

        private void number_six_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 6;
        }

        private void number_seven_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 7;
        }

        private void number_eight_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 8;
        }

        private void number_nine_Click(object sender, EventArgs e)
        {
            Error();
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 9;
        }

        private void clear_all_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = "0";
            history_screen.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            action = ' ';
            calculationCompleted = false;
            mainScreenIsClear = false;
            wasItDividedByOne = false;
            percentWasCalculated = false;
        }

        private void clear_entry_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = "0";
            firstNumber = 0;
        }

        private void equals_button_Click(object sender, EventArgs e)
        {
            Error();
            RemoveComma();
            if (!calculationCompleted)
            {
                secondNumber = double.Parse(main_screen.Text);
            }
            CalculationOfFields();
        }

        private void Error()
        {
            if (main_screen.Text == "Cannot divide by 0" || main_screen.Text == "Invalid input")
            {
                main_screen.Text = "0";
                history_screen.Text = "";
                firstNumber = 0;
                secondNumber = 0;
            }
        }

        private void comma_button_Click(object sender, EventArgs e)
        {
            Error();
            if (!FindAComma())
            {
                main_screen.Text += ",";
            }
        }

        private bool FindAComma()
        {
            foreach (var item in main_screen.Text)
            {
                if (item == ',')
                { 
                    return true;
                }
            }
            return false;
        }

        private void RemoveComma()
        {
            string test = main_screen.Text.Substring(main_screen.Text.Length - 1);
            if (test == ",")
            {
                main_screen.Text = main_screen.Text.Substring(0, main_screen.Text.Length - 1);
            }
        }




        private void ClearAllFields()
        {
            if (calculationCompleted && !mainScreenIsClear)
            {
                calculationCompleted = false;
                main_screen.Text = "";
                history_screen.Text = "";
                action = ' ';
            }
        }

        private void EraseTheMainField()
        {
            if (main_screen.Text.Length >= 2 && main_screen.Text[0] == '0' && main_screen.Text[1] == ',')
                return; 
            else if (mainScreenIsClear || main_screen.Text == "0")
            {
                main_screen.Text = "";
                mainScreenIsClear = false;
            }
        }

        private void swap_symbol_button_Click(object sender, EventArgs e)
        {
            Error();
            if (string.IsNullOrEmpty(main_screen.Text) || main_screen.Text == "-")
                return;
            string secondRoot;
            string newStringWithoutRoot;

            if (DoesHistoryScreenContainRootSymbol())
            {
                if (action == ' ')
                {
                    firstNumber = -firstNumber;
                    history_screen.Text = $"negate({history_screen.Text})";
                }
                else
                {
                    secondNumber = -secondNumber;

                    (secondRoot, newStringWithoutRoot) = CutSecondRoot();

                    history_screen.Text = newStringWithoutRoot + $"negate({secondRoot})";
                }
            }

            main_screen.Text = (-double.Parse(main_screen.Text)).ToString();
        }

        private (string secondRoot, string newStringWithoutRoot) CutSecondRoot()
        {
            int index = history_screen.Text.LastIndexOf(' ');

            if (index == -1)
                return (history_screen.Text, "");

            string secondRoot = history_screen.Text.Substring(index + 1);
            string newStringWithoutRoot = history_screen.Text.Substring(0, index + 1);

            return (secondRoot, newStringWithoutRoot);
        }



        private void backspace_button_Click(object sender, EventArgs e)
        {
            if (calculationCompleted)
            {
                calculationCompleted = false;
                history_screen.Text = " ";
            }
            else if (main_screen.Text.Length > 0)
            {
                if (!mainScreenIsClear)
                {
                    main_screen.Text = main_screen.Text.Substring(0, main_screen.Text.Length - 1);
                }
                if (main_screen.Text.Length == 0)
                {
                    main_screen.Text = "0";
                }
            }
        }

        
        private void add_button_Click(object sender, EventArgs e)
        {
            action = '+';
            SetOperation();
        }

        private void subtract_button_Click(object sender, EventArgs e)
        {
            action = '-';
            SetOperation();
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            action = '*';
            SetOperation();
        }

        private void divide_button_Click(object sender, EventArgs e)
        {
            action = '/';
            SetOperation();
        }

        private void SetOperation()
        {
            Error();
            RemoveComma();

            if(percentWasCalculated)
            {
                CalculationOfFields();
                percentWasCalculated = false;
            }
            else if (wasItDividedByOne)
            {
                history_screen.Text = $"{main_screen.Text} {action} ";
                main_screen.Text = "0";
                wasItDividedByOne = false;
                percentWasCalculated = false;
            }
            else if (DoesHistoryScreenContainAction())
            {
                secondNumber = double.Parse(main_screen.Text);
                percentWasCalculated = false;
                CalculationOfFields();
            }
            else if (history_screen.Text != "")
            {
                firstNumber = double.Parse(main_screen.Text);
                history_screen.Text += $" {action} ";
                mainScreenIsClear = true;
                percentWasCalculated = false;
            }
            else
            {
                firstNumber = double.Parse(main_screen.Text);
                history_screen.Text = $"{main_screen.Text} {action} ";
                mainScreenIsClear = true;
                percentWasCalculated = false;
            }
        }

        private void CalculationOfFields()
        {
            double result = 0;
            RemoveComma();

            switch (action)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;

                case '-':
                    result = firstNumber - secondNumber;
                    break;

                case '*':
                    result = firstNumber * secondNumber;
                    break;

                case '/':
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        main_screen.Text = "Cannot divide by 0";
                        return;
                    }
                    break;

                default:
                    return;
            }

            if (DoesHistoryScreenContainRootSymbol())
            {
                if (history_screen.Text.EndsWith($"{action} "))
                {
                    history_screen.Text += $"{secondNumber} =";
                }
                else if (!history_screen.Text.EndsWith(" ="))
                {
                    history_screen.Text += $" =";
                }
                else
                {
                    history_screen.Text = $"{firstNumber} {action} {secondNumber} =";
                }
            }
            else
                {
                    history_screen.Text = $"{firstNumber} {action} {secondNumber} =";
                }

            firstNumber = result;
            main_screen.Text = result.ToString();

            calculationCompleted = true;
            mainScreenIsClear = true;
        }

        private bool DoesHistoryScreenContainAction()
        {
            char[] symbols = { '+', '-', '*', '/' };
            foreach (var item in history_screen.Text)
            {
                foreach (var symbol in symbols)
                {
                    if (item == symbol)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

















        private void percent_button_Click(object sender, EventArgs e)
        {
            Error();

            if (action == ' ')
            {
                secondNumber = 0;
                history_screen.Text = "0";
                main_screen.Text = "0";
                percentWasCalculated = true;
                return;
            }

            secondNumber = double.Parse(main_screen.Text);

            switch (action)
            {
                case '+':
                case '-':
                    secondNumber = firstNumber * secondNumber / 100;
                    break;

                case '*':
                case '/':
                    secondNumber /= 100;
                    break;
            }

            history_screen.Text += secondNumber;
            main_screen.Text = secondNumber.ToString();
            percentWasCalculated = true;
        }




        private void square_root_button_Click_1(object sender, EventArgs e)
        {
            Error();

            double number = double.Parse(main_screen.Text);

            // БАГ ВИПРАВЛЕНО: корінь з від'ємного числа — показуємо помилку
            if (number < 0)
            {
                main_screen.Text = "Invalid input";
                return;
            }

            double root = Math.Sqrt(number);

            mainScreenIsClear = true;
            main_screen.Text = root.ToString();

            if (action == ' ')
            {
                firstNumber = root;
                history_screen.Text = $"√({number})";
            }
            else
            {
                secondNumber = root;
                string beforeSecondNumber = CutSecondNumberFromHistory();
                history_screen.Text = beforeSecondNumber + $"√({number})";
            }
            mainScreenIsClear = true;
        }

        private string CutSecondNumberFromHistory()
        {
            int index = history_screen.Text.LastIndexOf(' ');

            if (index == -1)
                return "";

            return history_screen.Text.Substring(0, index + 1);
        }

        private bool DoesHistoryScreenContainRootSymbol()
        {
            return history_screen.Text.Contains('√');
        }



        private void Squaring(object sender, EventArgs e)
        {
            Error();

            double number = double.Parse(main_screen.Text);
            double squared = number * number;

            if (action == ' ')
            {
                firstNumber = squared;
                history_screen.Text = $"sqr({number})";
            }
            else
            {
                secondNumber = squared;
                string beforeSecondNumber = CutSecondNumberFromHistory();
                history_screen.Text = beforeSecondNumber + $"sqr({number})";
            }

            main_screen.Text = squared.ToString();
            mainScreenIsClear = true;
        }

        private void Reciprocal_Click(object sender, EventArgs e)
        {
            Error();

            if (main_screen.Text == "0")
            {
                main_screen.Text = "Cannot divide by 0";
                return;
            }

            double number = double.Parse(main_screen.Text);
            double reciprocal = 1 / number;

            if (action == ' ')
            {
                firstNumber = reciprocal;
                history_screen.Text = $"1/({number})";
            }
            else
            {
                secondNumber = reciprocal;
                string beforeSecondNumber = CutSecondNumberFromHistory();
                history_screen.Text = beforeSecondNumber + $"1/({number})";
            }

            main_screen.Text = reciprocal.ToString();
            wasItDividedByOne = true;
            percentWasCalculated = true;
            mainScreenIsClear = true;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
