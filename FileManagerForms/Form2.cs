using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagerForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
           


            f.BackColor = Color.Yellow;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DiscList d = new DiscList();
            d.Find(label2.Text);
            listBox1.DataSource = d.ffiles;
            listBox1.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
