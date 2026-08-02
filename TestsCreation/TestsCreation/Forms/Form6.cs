using System;
using System.Drawing;
using System.Windows.Forms;
using TestsCreation.Forms;
using TestsCreation.Models;

namespace TestsCreation
{
    public partial class Form6 : Form
    {
        private Test Test { get; set; }
        private Timer timer;
        private int secondsLeft;
        private int Points { get; set; }
        private int currentQuestion = 1;

        public Form6(Test test)
        {
            InitializeComponent();
            Test = test;
            TestTimer();
            ShowQuestion();
            label1.Text = Test.ReturnTestName();
            if (currentQuestion >= Test.ReturnQuestionAndAnswers().Count)
            {
                button2.Visible = false;
            }
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
                if (currentQuestion >= Test.ReturnQuestionAndAnswers().Count)
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

            var question = Test.ReturnQuestionAndAnswers()[currentQuestion - 1];

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

        private void TestTimer()
        {
            timer = new Timer();
            secondsLeft = Test.GetTimeForTimer() * 60;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsLeft--;

            int hours = secondsLeft / 3600;
            int min = (secondsLeft % 3600) / 60;
            int sec = secondsLeft % 60;

            label4.Text = $"Time: {hours:D2}:{min:D2}:{sec:D2}";

            if (secondsLeft <= 0)
            {
                Form7 form7 = new Form7(Test, Points);
                form7.Dock = DockStyle.Fill;
                form7.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form7);
                form7.Show();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
