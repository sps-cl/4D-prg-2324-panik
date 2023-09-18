using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.models
{
    internal abstract class LibraryItem<T>
    {
        public int Id { get; }
        public string Title { get; }
        public bool IsAvilable { get; set; }

        public LibraryItem(int Id, string Title) {
            this.Id = Id;   
            this.Title = Title;   
            this.IsAvilable = true; 

        }

        public abstract void DisplayInfo();

    }
}
