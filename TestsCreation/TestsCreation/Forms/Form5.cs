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
using TestsCreation.Services;

namespace TestsCreation
{
    public partial class Form5 : Form
    {
        private JsonService JsonService;
        private Test[] Test;
        private Test _selectedTest;

        public Form5()
        {
            InitializeComponent();
            JsonService = new JsonService();
            Test = JsonService.JsonServiceDeSerializeTest();
            AddItemsToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (listBox1.SelectedItem != null)
            {
                _selectedTest = SelectedTest();
                Form6 form6 = new Form6(_selectedTest);
                form6.Dock = DockStyle.Fill;
                form6.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(form6);
                form6.Show();
            }
            label1.ForeColor = Color.Red;
            label1.Text = "Choose a test to take";
        }

        public void AddItemsToList()
        {
            foreach (var item in Test)
            {
                listBox1.Items.Add(item.ReturnTestName());
            }
        }

        public Test SelectedTest()
        {
            foreach (var item in Test)
            {
                if (listBox1.SelectedItem == item.ReturnTestName())
                {
                    return item;
                }
            }

            return null;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
