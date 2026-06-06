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

namespace TestsCreation
{
    public partial class MainForm : Form
    {
        public static Panel MainPanel;

        public MainForm()
        {
            InitializeComponent();
            MainPanel = formHolder;
        }

        private  void MainForm_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Dock = DockStyle.Left;
            form1.TopLevel = false;
            formHolder.Controls.Clear();
            formHolder.Controls.Add(form1);
            form1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
