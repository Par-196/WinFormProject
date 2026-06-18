using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestsCreation.Services;

namespace TestsCreation.Forms
{
    public partial class Form1 : Form 
    {
        private MainForm mainForm1;
        private JsonService JsonService;
        
        public Form1()
        {
            InitializeComponent();
            JsonService = new JsonService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Create_A_Test(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Dock = DockStyle.Fill;
            form2.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(form2);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (JsonService.AreThereTests())
            {
                Form5 form5 = new Form5();
                form5.Dock = DockStyle.Fill;
                form5.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form5);
                form5.Show();
            }
            else
            {
                Form8 form8 = new Form8();
                form8.Dock = DockStyle.Fill;
                form8.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form8);
                form8.Show();
            }
            
        }
    }
}
