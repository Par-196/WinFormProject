using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestsCreation.Forms;
using TestsCreation.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestsCreation
{
    public partial class Form6 : Form
    {
        private Test Test { get; set; }
        private int Points { get; set; }
        private int currentQuestion = 0;


        public Form6(Test test)
        {
            InitializeComponent();
            Test = test;
            ShowQuestion();
            label1.Text = Test.ReturnTestName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                label3.Text = "";
                if (CheckingTheCorrectAnswer() && currentQuestion < Test.ReturnQuestionAndAnswers().Count)
                {
                    Points += Test.Scoring();
                }
                Form7 form7 = new Form7(Test, Points);
                form7.Dock = DockStyle.Fill;
                form7.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form7);
                form7.Show();
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "You must choose an answer";
            }
        }

        private void next_Question(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                label3.Text = "";
                if (CheckingTheCorrectAnswer())
                {
                    Points += Test.Scoring();
                }

                currentQuestion++;

                ShowQuestion();
                if (currentQuestion + 1 >= Test.ReturnQuestionAndAnswers().Count)
                {
                    button2.Visible = false;
                }
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "You must choose an answer";
            }
        }
        
        private void ShowQuestion() 
        {
            listBox1.Items.Clear();

            var question = Test.ReturnQuestionAndAnswers()[currentQuestion];

            label2.Text = question.ReturnQuestion();

            foreach (var answer in question.ReturnResponds())
            {
                listBox1.Items.Add(answer.ReturnAnswer());
            }
        }

        private bool CheckingTheCorrectAnswer()
        {
            foreach (var testItems in Test.ReturnQuestionAndAnswers())
            {
                foreach (var respond in testItems.ReturnResponds())
                {
                    if (listBox1.SelectedItem == respond.ReturnAnswer() &&
                        respond.ReturnBoolean() == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
