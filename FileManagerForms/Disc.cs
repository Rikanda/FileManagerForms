using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagerForms
{
    public class Disc
    {
        public string Dname { get; set; }
        public int Dindex { get; set; }

        DriveInfo DrI { get; set; }

        public List<Directory> dList  = new List<Directory>();
        public List<File> fList = new List<File>();


        public Disc(string name_, int index_, DriveInfo driveInfo_)
        {

            Dname = name_;
            Dindex = index_;
            DrI = driveInfo_;
            
        }

        public void DiscIntro() // содержимое диска
        {
          //  Disc root = this; // запоминаем родителя
         //   DirectoryList<Disc> dl = new(root); // создаем объект для заполнения каталогов внутри родителя
            

            string[] introDirectory = System.IO.Directory.GetDirectories(Dname); // получаем список каталогов из системы
            
          //  DirectoryInfo[] introDirectory = 
            string i;
            string path_;
            int n = 0;
            foreach (var str in introDirectory)
            {
                DirectoryInfo di = new DirectoryInfo(str);
                path_ = System.IO.Directory.GetCurrentDirectory();
                i = str;
                Directory d = new Directory(str, n, path_, this, di);
                dList.Add(d);
                n++;
                
            }

            n = 0;
            string[] introFile = System.IO.Directory.GetFiles(Dname);
            foreach (var str in introFile)
            {
                FileInfo fi = new FileInfo(str);
                path_ = str;
                i= str;
                File f = new File(str, n, path_, this, fi);
                fList.Add(f);
                n++;
            }

        }

       
    }
}
