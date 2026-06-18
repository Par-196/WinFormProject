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
using TestsCreation.Services;

namespace TestsCreation
{
    public partial class Form3 : Form
    {
        private Test Test;
        private JsonService JsonService;
        public Form3(Test test)
        {
            InitializeComponent();
            Test = test;
            JsonService = new JsonService();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Red;
            if (CheckingTextBox1() & CheckSelectedItemInList())
            {
                var questionAnswers = new QuestionAnswers(textBox1.Text, SelectRespond());
                Test.AddQuestionAnswersToTest(questionAnswers);
                JsonService.JsonServiceSerializeTest(Test);
                Form4 form4 = new Form4();
                form4.Dock = DockStyle.Fill;
                form4.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form4);
                form4.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Red;
            if (CheckingTextBox1() & CheckSelectedItemInList())
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

        private bool CheckSelectedItemInList()
        {
            if (listBox1.Items.Count == null || listBox1.Items.Count <= 1)
            {
                label5.Text = "Add at least 2 answers";
                return false;
            }
            else if (listBox1.SelectedItem == null )
            {
                label5.Text = "Select the item, this will be the correct answer";
                return false;
            }
            label5.Text = "";
            return true;
        }

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
                label3.Text = "";
                if (!AreThereAnyRepeatedWordsInTheList())
                {
                    listBox1.Items.Add(textBox2.Text);
                    textBox2.Text = string.Empty;
                }
            }
        }

        private bool AreThereAnyRepeatedWordsInTheList()
        {
            foreach (var item in listBox1.Items)
            {
                if (listBox1.Items.Count > 0 && textBox2.Text == item.ToString())
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "You cannot add 2 identical answers";
                    return true;
                }
            }

            return false;
        }
        
        private List<Respond> SelectRespond()
        {
            List<Respond> respond = new List<Respond>();

            if (listBox1.SelectedItem == null)
                return respond;

            foreach (var item in listBox1.Items)
            {
                bool isSelected = item.ToString() == listBox1.SelectedItem.ToString();

                Respond respond1 = new Respond(isSelected, item.ToString());
                respond.Add(respond1);
            }

            return respond;
        }
    }
}
