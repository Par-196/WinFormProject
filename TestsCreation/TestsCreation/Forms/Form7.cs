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

namespace TestsCreation.Forms
{
    public partial class Form7 : Form
    {
        private Test Test { get; set; }
        public Form7(Test test, int Points)
        {
            InitializeComponent();
            Test = test;
            label2.Text = $"Test completed Your scored: {Points}/{test.ReturnPoints()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Dock = DockStyle.Fill;
            form1.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(form1);
            form1.Show();
        }
    }
}
