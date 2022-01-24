namespace FileManagerForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

            DiscList d = new DiscList();
            foreach (Disc dc in d.list)
            {
                dc.DiscIntro();
            }
            comboBox1.DataSource = d.list;
            comboBox1.DisplayMember = "Dname";
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
             Disc disc =(Disc)comboBox1.SelectedItem;
            foreach (Directory dd in disc.dList)
            {
                listBox1.Items.Add(dd);
                listBox1.DisplayMember = "Name";

            }

            foreach (File ff in disc.fList)
                    {
                        listBox1.Items.Add(ff);
                        listBox1.DisplayMember = "Name";
                        listBox1.SelectedIndex = 0;

                    }
                  

                    tabPage1.Text = disc.Dname;
                

        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedItem.GetType() == typeof(File))
            {
                File ff = (File)listBox1.SelectedItem;
                label3.Text = "“ËÔ: "+ff.TypeEntity.ToString();
                label4.Text = ff.GetSize();
                button1.Visible = false;
            }

            if (listBox1.SelectedItem.GetType() == typeof(Directory))
            {
                Directory dd = (Directory)listBox1.SelectedItem;
                label3.Text = "“ËÔ: "+ dd.TypeEntity.ToString();
                label4.Text = dd.GetSize();
                button1.Visible = true;
            }



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            TabPage newTabPage = new TabPage();
            Directory dd = (Directory)listBox1.SelectedItem;
            newTabPage.Text = dd.Name;
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
            ListBox newListBox = new ListBox();
            newListBox.Location = new Point(6, 57);
            newListBox.Width = 757;
            newListBox.Height = 324;
            newTabPage.Controls.Add(newListBox);
            dd.DirectoryIntro();
 

            foreach (Directory subdd in dd.dList)
            {
               newListBox.Items.Add(subdd);
               newListBox.DisplayMember = "Name";

            }

            foreach (File ff in dd.fList)
            {
                newListBox.Items.Add(ff);
               newListBox.DisplayMember = "Name";
                newListBox.SelectedIndex = 0;

            }




        }
    }
}