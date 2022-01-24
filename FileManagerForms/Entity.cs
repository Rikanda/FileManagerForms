using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerForms
{
    public enum Type
    {
        Directory,
        File
    }

    public interface IEntityMethod
    {
        public abstract void Create();
        public abstract void Delete();

        public abstract void Rename(string newName);

        public abstract string GetSize();

        public abstract void Copy(Disc d, string path);

        public abstract void Move(Disc new_dics, string new_path);

    }
    public abstract class Entity
    {
        public Entity(string name_, int index_,  string path_, Disc rd_)
        {
            Name = name_;
            Index = index_;         
            Path = path_;
            RootDisc = rd_;
        }

        public abstract string Name { get; set; } // имя
        public abstract int Index { get; set; } // индекс
        public abstract Type TypeEntity { get; set; } // тип объекта: файл или каталог
        public abstract string Path { get; set; } // путь к объекту
        public abstract Disc RootDisc { get; set; } // корневой диск

 
    }
}
