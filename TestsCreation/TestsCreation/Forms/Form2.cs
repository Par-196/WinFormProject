using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestsCreation.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestsCreation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Check_TextBox1() & Check_TextBox2() & Check_TextBox3())
            {
                Test test = new Test();
                test.AddNameTimeAndPointsToTest(textBox1.Text, Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text));
                Form3 form3 = new Form3(test);
                form3.Dock = DockStyle.Fill;
                form3.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form3);
                form3.Show();
            }
        }

        private bool Check_TextBox1()
        {
            label4.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label4.Text = "You must fill in the field";
                return false;
            }
            else if (CheckSymbolsInTestName(textBox1.Text))
            {
                label4.Text = "You cannot use the following special characters";
                return false;
            }
            else if (CheckReservedLegacyDeviceNames(textBox1.Text))
            {
                label4.Text = "You cannot use a reserved name";
                return false;
            }
            else if (textBox1.Text.Length > 255)
            {
                label4.Text = "The length cannot exceed 255 characters.";
                return false;
            }
            label4.Text = "";
            return true;
        }

        private bool Check_TextBox2()
        {
            label5.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label5.Text = "You must fill in the field";
                return false;
            }
            else if(!Int32.TryParse(textBox2.Text, out int textBox2Number))
            {
                label5.Text = "The field must contain numbers";
                return false;
            }
            else if (textBox2Number <= 0)
            {
                label5.Text = "Time cannot be negative";
                return false;
            }
            else if (textBox2Number > 300)
            {
                label5.Text = "Maximum 300 minutes";
                return false;
            }
            label5.Text = "";
            return true;
        }

        private bool Check_TextBox3()
        {
            label6.ForeColor = Color.Red;
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                label6.Text = "You must fill in the field";
                return false;
            }
            else if (!Int32.TryParse(textBox3.Text, out int textBox3Number))
            {
                label6.Text = "The field must contain numbers";
                return false;
            }
            else if (textBox3Number <= 0)
            {
                label6.Text = "The score cannot be negative";
                return false;
            }
            else if (textBox3Number > 100)
            {
                label6.Text = "Points cannot be more than 100";
                return false;
            }
            label6.Text = "";
            return true;
        }

        private bool CheckSymbolsInTestName(string textBox1)
        {
            string[] reservedSymbol =
            {
                "\\", "|", "/", "*", ":", "?", "\"", "<", ">"
            };
            if (reservedSymbol.Any(symbol => textBox1.Contains(symbol)))
            {
                return true;
            }
            return false;
        }

        private bool CheckReservedLegacyDeviceNames(string textBox1)
        {
            string[] reservedNames =
            {
                "CON", "PRN", "AUX", "NUL",
                "COM1", "COM2", "COM3", "COM4", "COM5",
                "COM6", "COM7", "COM8", "COM9",
                "COM¹", "COM²", "COM³",
                "LPT1", "LPT2", "LPT3", "LPT4", "LPT5",
                "LPT6", "LPT7", "LPT8", "LPT9",
                "LPT¹", "LPT²", "LPT³"
            };

            string name = textBox1.Split('.')[0].ToUpper();

            if (reservedNames.Contains(name.ToUpper()))
            {
                return true;
            }
            return false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
