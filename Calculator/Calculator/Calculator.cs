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

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool mainScreenIsClear;

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
        }

        private void clear_entry_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = "0";
        }

        private void equals_button_Click(object sender, EventArgs e)
        {
            CalculationOfFields(FindSymbol());
        }

        private void ClearAllFields()
        {
            if (FindSymbol() == '=' && !mainScreenIsClear)
            {
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
            main_screen.Text = (-decimal.Parse(main_screen.Text)).ToString();
        }



        private void backspace_button_Click(object sender, EventArgs e)
        {
            if (FindSymbol() == '=')
            {
                history_screen.Text = " ";
            }
            else if (main_screen.Text.Length > 0)
            {
                if (!mainScreenIsClear)
                {
                    main_screen.Text = main_screen.Text.Substring(0, main_screen.Text.Length - 1);
                }
            }
        }



        private char FindSymbol()
        {
            char[] symbolsArray = { '=', '+', '-', '*', '/' };
            string reverseHistoryScreen = new string(history_screen.Text.Reverse().ToArray());
            foreach (var symbols in symbolsArray)
            {
                foreach (var item in reverseHistoryScreen)
                {
                    if (item == symbols)
                    {
                        return symbols;
                    }
                }
            }
            return ' ';
        }





        private void add_button_Click(object sender, EventArgs e)
        {
            GG('+');
        }

        private void subtract_button_Click(object sender, EventArgs e)
        {
            GG('-');
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            GG('*');
        }

        private void divide_button_Click(object sender, EventArgs e)
        {
            GG('/');
        }

        private void GG(char symbol)
        {
            if (history_screen.Text != "" && !mainScreenIsClear)
            {
                CalculationOfFields(FindSymbol()); 
            }
            mainScreenIsClear = true;
            history_screen.Text = $"{main_screen.Text} {symbol}";
        }

        

        

        

        private void CalculationOfFields(char symbol)
        {
            decimal result = 0;
            if (symbol == '=')
            {
                history_screen.Text = main_screen.Text;
            }
            else
            {
                
                decimal main_screen_number = decimal.Parse(main_screen.Text);
                decimal history_screen_number = ReturnNumberOutOfHistoryScreen();
                result = 0;

                switch (symbol)
                {
                    case '+':
                        {
                            result = history_screen_number + main_screen_number;
                        }
                        break;
                    case '-':
                        {
                            result = history_screen_number - main_screen_number;
                        }
                        break;
                    case '*':
                        {
                            result = history_screen_number * main_screen_number;
                        }
                        break;
                    case '/':
                        {
                            if (main_screen.Text[0] != '0' && main_screen.Text.Length > 0)
                            {
                                result = history_screen_number / main_screen_number;
                            }
                        }
                        break;
                }
                char oldSymbol = symbol;
                symbol = '=';
                mainScreenIsClear = true;
                history_screen.Text = $"{history_screen_number.ToString()} {oldSymbol.ToString()} {main_screen_number.ToString()} {symbol.ToString()} ";
                main_screen.Text = result.ToString();
            }
        }

        private decimal ReturnNumberOutOfHistoryScreen()
        {
            string reverseHistoryScreen = new string(history_screen.Text.Reverse().ToArray());
            
            return decimal.Parse(reverseHistoryScreen = reverseHistoryScreen.Substring(1));
        }




        private void comma_button_Click(object sender, EventArgs e)
        {
            if (FindAComma())
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
                    return false;
                }
            }
            return true;
        }

      

        private void square_root_button_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {

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
            decimal main_screen_number = decimal.Parse(main_screen.Text);
            if (main_screen_number / 2 == -1)
            { 
                
            }
        }

        private void Squaring(object sender, EventArgs e)
        {
            decimal main_screen_number = decimal.Parse(main_screen.Text);
            main_screen_number *= main_screen_number;
            main_screen.Text = main_screen_number.ToString();
        }
    }
}
