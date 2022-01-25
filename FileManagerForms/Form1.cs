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
           
            comboBox1.DataSource = d.list;
            comboBox1.DisplayMember = "Dname";
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
               
             Disc disc =(Disc)comboBox1.SelectedItem;
 //           disc.DiscIntro();
            UpdateDisc(disc);
                

        }

        

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedItem.GetType() == typeof(File))
            {
                File ff = (File)listBox1.SelectedItem;
                label3.Text = "“ËÔ: "+ff.TypeEntity.ToString();
                label4.Text = ff.GetSize();
                
            }

            if (listBox1.SelectedItem.GetType() == typeof(Directory))
            {
                Directory dd = (Directory)listBox1.SelectedItem;
                label3.Text = "“ËÔ: "+ dd.TypeEntity.ToString();
                label4.Text = dd.GetSize();
               
            }



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Directory dd = (Directory)listBox1.SelectedItem;
            UpdateDirectory(dd);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem.GetType() == typeof(File))
            {
                FileBack();
            }

            if (listBox1.SelectedItem.GetType() == typeof(Directory))
            {
                
                DirectoryBack();
            }
            

        }

        private void UpdateDirectory(Directory df)
        {
           
            df.DirectoryIntro();
            listBox1.Items.Clear();
            foreach (Directory dd in df.dList)
            {
                listBox1.Items.Add(dd);
                listBox1.DisplayMember = "Name";

            }

            foreach (File ff in df.fList)
            {
                listBox1.Items.Add(ff);
                listBox1.DisplayMember = "Name";
                listBox1.SelectedIndex = 0;

            }
            label1.Text = df.Name;
        }

        private void UpdateDisc(Disc disc)
        {
            
              disc.DiscIntro();
            listBox1.Items.Clear();
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

            label1.Text = disc.Dname;
           

        }

        private void DirectoryBack()
        {
            Disc disc = (Disc)comboBox1.SelectedItem;
            Directory dd0 = (Directory)listBox1.SelectedItem;
            Directory dd1 = dd0.ParentDir;
            if(dd1 == null)
            {
                UpdateDisc(disc);
            }
            else
            {
                Directory df = dd1.ParentDir;
                if (df == null)
                {
                    UpdateDisc(disc);
                }
                else
                {
                    UpdateDirectory(df);

                }

            }
            


        }

        private void FileBack()
        {
            Disc disc = (Disc)comboBox1.SelectedItem;
            File ff1 = (File)listBox1.SelectedItem;
            Directory dd1 = ff1.ParenthDir;
            if(dd1 == null)
            {
                UpdateDisc(disc);
            }
            else
            {
                Directory df = dd1.ParentDir;

                if (df == null)
                {
                    UpdateDisc(disc);
                }
                else
                {
                    UpdateDirectory(df);


                }
            }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.GetType() == typeof(File))
            {
                FileBack();
            }
            else if (listBox1.SelectedItem.GetType() == typeof(Directory))
            {
                DirectoryBack();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.GetType() == typeof(Directory))
            {
                
                Directory dd = (Directory)listBox1.SelectedItem;
        //        dd.DirectoryIntro();
                UpdateDirectory(dd);
            }
                
        }
    }
}