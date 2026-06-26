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

        public Calculator()
        {
            InitializeComponent();
            main_screen.Text = "0";
        }

        private void number_zero_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 0;
        }

        private void number_one_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 1; 
        }

        private void number_two_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 2;
        }

        private void number_three_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 3;
        }

        private void number_four_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 4;
        }

        private void number_five_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 5;
        }

        private void number_six_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 6;

        }

        private void number_seven_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 7;
        }

        private void number_eight_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            ClearAllFields();
            main_screen.Text += 8;
        }

        private void number_nine_Click(object sender, EventArgs e)
        {
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
        }

        private void clear_entry_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = "0";
            firstNumber = 0;
        }

        private void equals_button_Click(object sender, EventArgs e)
        {
            RemoveComma();
            if (!calculationCompleted)
            {
                secondNumber = double.Parse(main_screen.Text);
            }
            CalculationOfFields();
        }
        
        private void comma_button_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void EraseTheMainField()
        {
            if (main_screen.Text.Length > 1 && main_screen.Text[0] == '0' && main_screen.Text[1] == ',')
                return;
            else if (mainScreenIsClear || main_screen.Text[0] == '0')
            {
                main_screen.Text = "";
                mainScreenIsClear = false;
             }
        }

        private void swap_symbol_button_Click(object sender, EventArgs e)
        {
            if (FindAComma())
            {
                main_screen.Text = $"{(-decimal.Parse(main_screen.Text))}";
            }
            else
            {
                main_screen.Text = (-decimal.Parse(main_screen.Text)).ToString();
            }  
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
            RemoveComma();
            if (DoesHistoryScreenContainAction())
            {
                secondNumber = double.Parse(main_screen.Text);
                CalculationOfFields();
            }
            else if (DoesHistoryScreenContainRootSymbol())
            {
                mainScreenIsClear = true;
                history_screen.Text += $" {action} ";
            }
            else if (history_screen.Text != "")
            {
                secondNumber = double.Parse(main_screen.Text);
                CalculationOfFields();
            }
            else
            {
                mainScreenIsClear = true;
                firstNumber = double.Parse(main_screen.Text);
                history_screen.Text = $"{main_screen.Text} {action}";
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
                if (!history_screen.Text.EndsWith(" ="))
                {
                    history_screen.Text += " =";
                }
                else
                {
                    history_screen.Text = $"{result} {action} {secondNumber} =";
                }
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
            decimal main_number = decimal.Parse(main_screen.Text);
            decimal history_number = decimal.Parse(history_screen.Text);
            decimal total_number = history_number * main_number / 100;
            history_screen.Text += $"{total_number.ToString()}";
            main_screen.Text = total_number.ToString();
        }

        


        private void square_root_button_Click_1(object sender, EventArgs e)
                         {
            mainScreenIsClear = true;
            if (history_screen.Text != "" && !DoesHistoryScreenContainRootSymbol())
            {
                history_screen.Text += $"√({main_screen.Text})";
                secondNumber = Math.Sqrt(double.Parse(main_screen.Text));
                main_screen.Text = secondNumber.ToString();
            }
            else if (history_screen.Text != "" && DoesHistoryScreenContainRootSymbol() && action == ' ')
            {
                history_screen.Text = $" √({history_screen.Text})";
                firstNumber = Math.Sqrt(double.Parse(main_screen.Text));
                main_screen.Text = firstNumber.ToString();
            }
            else  if (DoesHistoryScreenContainRootSymbol() && action != ' ')
            {
                history_screen.Text += $"√({main_screen.Text})";    
                secondNumber = Math.Sqrt(double.Parse(main_screen.Text));
                main_screen.Text = secondNumber.ToString();
            }
            else if (history_screen.Text == "")
            {
                history_screen.Text += $"√({main_screen.Text})";
                firstNumber = Math.Sqrt(double.Parse(main_screen.Text));
                main_screen.Text = firstNumber.ToString();
            }
        }

        private bool DoesHistoryScreenContainRootSymbol()
        {
            return history_screen.Text.Contains('√');
        }

        


        private void Squaring(object sender, EventArgs e)
        {
            decimal main_screen_number = decimal.Parse(main_screen.Text);
            main_screen_number *= main_screen_number;
            main_screen.Text = main_screen_number.ToString();
        }

        private void Reciprocal_Click(object sender, EventArgs e)
        {

        }
    }
}
