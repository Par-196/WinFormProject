using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private bool clearMainScreen;

        public Calculator()
        {
            InitializeComponent();
            main_screen.Text = "0";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void number_zero_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 0;
        }

        private void number_one_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 1; 
        }

        private void number_two_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 2;
        }

        private void number_three_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 3;
        }

        private void number_four_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 4;
        }

        private void number_five_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 5;
        }

        private void number_six_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 6;

        }

        private void number_seven_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 7;
        }

        private void number_eight_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 8;
        }

        private void number_nine_Click(object sender, EventArgs e)
        {
            EraseTheMainField();
            main_screen.Text += 9;
        }

        private void clear_all_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = "0";
            symbol_screen.Text = "";
            history_screen.Text = "";
        }

        private void clear_entry_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = "0";
        }

        private void backspace_button_Click(object sender, EventArgs e)
        {
            if (main_screen.Text.Length > 1)
            {
                if (symbol_screen.Text == "" || !clearMainScreen)
                {
                    main_screen.Text = main_screen.Text.Substring(0, main_screen.Text.Length - 1);
                }
            }
        }









        private void add_button_Click(object sender, EventArgs e)
        {
            if (history_screen.Text != "")
            {
                CalculationOfFields();
            }
            symbol_screen.Text = "+";
            clearMainScreen = true;
            history_screen.Text = main_screen.Text;
        }

        private void subtract_button_Click(object sender, EventArgs e)
        {
            if (history_screen.Text != "")
            {
                CalculationOfFields();
            }
            symbol_screen.Text = "-";
            clearMainScreen = true;
            history_screen.Text = main_screen.Text;
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            if (history_screen.Text != "")
            {
                CalculationOfFields();
            }
            symbol_screen.Text = "*";
            clearMainScreen = true;
            history_screen.Text = main_screen.Text;
        }

        private void divide_button_Click(object sender, EventArgs e)
        {
            if (history_screen.Text != "")
            {
                CalculationOfFields();
            }
            symbol_screen.Text = "/";
            clearMainScreen = true;
            history_screen.Text = main_screen.Text;
        }



        



        private void equals_button_Click(object sender, EventArgs e)
        {
            CalculationOfFields();
        }

        private void EraseTheMainField()
        {
            if (main_screen.Text.Length > 1 && main_screen.Text[0] == '0' && main_screen.Text[1] == ',')
                return;
            else if (clearMainScreen || main_screen.Text[0] == '0')
            {
                main_screen.Text = "";
                clearMainScreen = false;
            }
        }

        private void CalculationOfFields()
        {
            decimal result = 0;
            if (symbol_screen.Text == "" || symbol_screen.Text == "=")
            {
                history_screen.Text = main_screen.Text;
                symbol_screen.Text = "=";
            }
            else
            {
                decimal main_screen_number = decimal.Parse(main_screen.Text);
                decimal history_screen_number = decimal.Parse(history_screen.Text);
                result = main_screen_number;


                switch (symbol_screen.Text)
                {
                    case "+":
                        {
                            result = history_screen_number + main_screen_number;
                        }
                        break;
                    case "-":
                        {
                            result = history_screen_number - main_screen_number;
                        }
                        break;
                    case "*":
                        {
                            result = history_screen_number * main_screen_number;
                        }
                        break;
                    case "/":
                        {
                            if (main_screen.Text[0] != '0' && main_screen.Text.Length < 1)
                            {
                                result = history_screen_number / main_screen_number;
                            }
                        }
                        break;
                }
                history_screen.Text = history_screen_number.ToString() + " " + symbol_screen.Text + " " + main_screen_number.ToString();
                symbol_screen.Text = "=";
            }
            main_screen.Text = result.ToString();
        }

        private void swap_symbol_button_Click(object sender, EventArgs e)
        {
            main_screen.Text = (-decimal.Parse(main_screen.Text)).ToString();
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

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void square_root_button_Click(object sender, EventArgs e)
        {

        }

        private void percent_button_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

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
