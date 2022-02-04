using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FileManagerForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 f1)
        {
            InitializeComponent();
            
           // this.Close();
       
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            

            DiscList d = new DiscList();
            string name = label2.Text;
            Form2 newForm = new Form2(this);
            newForm.label2.Text = label2.Text;
            Action onCompleted = () =>
            {
                newForm.listBox1.DataSource = d.ffiles;
                newForm.listBox1.DisplayMember = "Name";
                newForm.Show();
                this.Close();
            };

            Thread mt = new Thread(() =>
            {
                try
                {
                    d.Find(name);
                                
                }
                finally
                {
                    this.Invoke(onCompleted);
                }
                
            });
           // mt.IsBackground = true;
            mt.Start();
            


            











        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
