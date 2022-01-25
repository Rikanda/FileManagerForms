using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerForms
{
    public class File : Entity, IEntityMethod
    {
        public override string Name { get; set; }
        public override int Index { get; set; }
        public override Type TypeEntity { get; set; }
        public override string Path { get; set; }
        public override Disc RootDisc { get; set; }
        public FileInfo FI { get; set; }

        public Directory ParenthDir { get; set; }
        public File(string name_, int index_, string path_, Disc rd_, FileInfo fi_, Directory pd_) : base(name_, index_, path_, rd_)
        {
            TypeEntity = Type.File;
            FI = fi_;
            ParenthDir = pd_;
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
            string size_info = "Размер файла - " + (FI.Length / 1024).ToString() + "KB";
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
    }
}
