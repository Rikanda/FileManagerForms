using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerForms
{
    public class Directory : Entity, IEntityMethod
    {
        public List<Directory> dList = new List<Directory>(); // список входящих в каталог каталогов
        public List<File> fList = new List<File>();// список входящих в каталог файлов

        public override string Name { get; set; }
        public override int Index { get; set; }
        public override Type TypeEntity { get; set; }
        public override string Path { get; set; }
        public override Disc RootDisc { get; set; }
        public DirectoryInfo DI { get; set; }
        public Directory(string name_, int index_, string path_, Disc rd_, DirectoryInfo di_) : base(name_, index_, path_, rd_)
        {
            TypeEntity = Type.Directory;
             DI = di_;
        }

        public void DirectoryIntro() // содержимое директории
        {
            //  Disc root = this; // запоминаем родителя
            //   DirectoryList<Disc> dl = new(root); // создаем объект для заполнения каталогов внутри родителя


            string[] introDirectory = System.IO.Directory.GetDirectories(Name); // получаем список каталогов из системы


            string i;
            string path_;
            int n = 0;
            foreach (var str in introDirectory)
            {
                DirectoryInfo di = new DirectoryInfo(str);
                path_ = System.IO.Directory.GetCurrentDirectory();
                i = str;
                Directory d = new Directory(str, n, path_, this.RootDisc, di);
                dList.Add(d);
                n++;

            }

            n = 0;
            string[] introFile = System.IO.Directory.GetFiles(Name);
            foreach (var str in introFile)
            {
                FileInfo fi = new FileInfo(str);
                path_ = str;
                i = str;
                File f = new File(str, n, path_, this.RootDisc, fi);
                fList.Add(f);
                n++;
            }
        }


            public void Copy(Disc d, string path)
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public string GetSize()
        {

            string size_info = GetTotalSize(Name);
            return size_info;
        }

        public void Move(Disc new_dics, string new_path)
        {
            throw new NotImplementedException();
        }

        public void Rename(string newName)
        {
            throw new NotImplementedException();
        }


        private double totalSize = 0;

        public string GetTotalSize(string directory)
        {
            //Инициализируем новую переменную 
            //общего размера директории.
            string folderSize = string.Empty;
            //Получаем список файлов в текущей директории.
            try
            {
                string[] files = System.IO.Directory.GetFiles(directory);


                

                //Проходимся по всем найденным файлам.
                foreach (string file in files)
                {
                    //Складываем размер файлов текущей 
                    //директории.
                    try
                    { GetFileSize(file); }
                    catch { continue; }

                }
            }
            catch { }
            //Вызываем метод GetDirectories с передачей в качестве параметра, пути к 
            //текущей директории. Данный метод возвращает
            //массив имен подкаталогов.
            try
            {
                string[] subDirs = System.IO.Directory.GetDirectories(directory);
                //Проходимся по всем полученным подкаталогам.
                foreach (string dir in subDirs)
                {
                    //Вызов метода получения размера 
                    //текущего подкаталога.
                    try { GetFileSize(dir); }
                    catch { continue; }
                }
            }
            catch {  }

            
                
                    //Возвращение полученного размера директории в
                    //килобайтах.
                 folderSize = "Размер каталога - " + (totalSize / Math.Pow(1024, 1)).ToString() + " Кб.";
                    
            

            return folderSize;
        }

        private void GetFileSize(string path)
        {
            //Берем текущий файл в текущей директории.
            System.IO.FileInfo fi = new System.IO.FileInfo(path);
            //Получаем размер текущего файла в байтах и 
            //прибавляем его к общему размеру директории.
            totalSize += fi.Length;
        }
    }

}
