using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagerForms
{
    public class DiscList
    {
        
            public  List<Disc> list { get; set; }

            public List<File> ffiles { get; set; } = new List<File>(); // список найденных файлов

            public DiscList()
            {

                DriveInfo[] drv = DriveInfo.GetDrives();

                list = new List<Disc>();
                string i;
                int n = 0;
                foreach (DriveInfo drv_ in drv)
                {
                    i = drv_.Name;
                    Disc d = new Disc(i, n, drv_);
                    list.Add(d);
                    n++;
                }

            }
            
        
        public void Find (string name) // метод поиска
        {
            foreach(Disc d in list) // обход дисков
            {
                d.DiscIntro(); // состав диска
                add_file(d.fList, name); //вызов поиска файла в списке
                check_dir(d.dList, name); // вызов проверки директории
                
            }

        }

        public void add_file(List<File> lf, string name) // поиск файла с совпадающим именем
        {
            foreach (File f in lf)
            {
                string s = Path.GetFileNameWithoutExtension(f.Name); // название файла
                int ind = s.IndexOf(name); // поиск по подстроке

                if (ind!=-1) // если что-то найдено
                {
                    ffiles.Add(f); // добавляем найденный файл в список для отображения

                }
            }

        }

        public void check_dir(List<Directory> ld, string name) // проверка директории
        {
            foreach (Directory dir in ld)  // обход директорий в списке директории
            {
          //      Q.Enqueue(dir); // добавление в очередь на обработку
           //     if (Q.Count > 0) // если очередь не пустая
           //     {
           //         Directory n = Q.Dequeue(); // берем элемент из очереди
                    dir.DirectoryIntro(); // формирование содержимого директории
                    add_file(dir.fList, name); // поиск файла в директории

                    check_dir(dir.dList, name); // вызов обработки подкаталогов
              //  }
              //  else return;
            }


        }
        //    public void prntDirectory(int index)
        //    {
        //        foreach (Disc d in list)
        //        {
        //            if (d.Dindex == index)
        //            {
        //                d.DiscIntro();
        //                break;
        //            }
        //        }
        //    }
        }
    
}
