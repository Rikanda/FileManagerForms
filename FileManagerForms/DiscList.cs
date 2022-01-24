using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagerForms
{
    internal class DiscList
    {
        
            public List<Disc> list { get; set; }

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


            public void prntDirectory(int index)
            {
                foreach (Disc d in list)
                {
                    if (d.Dindex == index)
                    {
                        d.DiscIntro();
                        break;
                    }
                }
            }
        }
    
}
