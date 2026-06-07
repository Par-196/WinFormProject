using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestsCreation.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestsCreation
{
    public partial class Form3 : Form
    {
        private Test Test;

        public Form3(Test test)
        {
            InitializeComponent();
            Test = test;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var questionAnswers = new QuestionAnswers(textBox1.Text, SelectRespond());
            Test.AddQuestionAnswersToTest(questionAnswers);
            Form4 form4 = new Form4();
            form4.Dock = DockStyle.Fill;
            form4.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(form4);
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Red;
            if (CheckingTextBox1() & CheckingTextBox2() & CheckSelectedItemInList())
            {
                var questionAnswers = new QuestionAnswers(textBox1.Text, SelectRespond());
                Test.AddQuestionAnswersToTest(questionAnswers);
                Form3 form3 = new Form3(Test);
                form3.Dock = DockStyle.Fill;
                form3.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form3);
                form3.Show();
            }
        }

        private bool CheckingTextBox2()
        {
            if (listBox1.Items.Count == 0)
            {
                label3.Text = "Add answers";
                return false;
            }
            label3.Text = "";
            return true;
        }
        // не можу бути одна відповдіь
        // Finish test має нажиматись просто так 
        private bool CheckingTextBox1()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label4.Text = "You must fill in the field";
                return false;
            }
            else if (textBox1.Text.Length > 50)
            {
                label4.Text = "The length cannot exceed 50 characters";
                return false;
            }
            label4.Text = "";
            return true;
        }

        private bool CheckSelectedItemInList()
        {
            if (listBox1.SelectedItem == null)
            {
                label5.Text = "Select the item, this will be the correct answer";
                return false;
            }
            label5.Text = "";
            return true;
        }

        private List<Respond> SelectRespond()
        {
            List<Respond> respond = new List<Respond>();
            
            foreach (var item in listBox1.Items)
            {
                if (item == listBox1.SelectedItem.ToString())
                {
                    Respond respond1 = new Respond(true, item.ToString());
                    respond.Add(respond1);
                }
                else if (item != listBox1.SelectedItem.ToString())
                {
                    Respond respond1 = new Respond(false, item.ToString());
                    respond.Add(respond1);
                }
            }
            return respond;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = string.Empty;
            }
        }
    }
}
