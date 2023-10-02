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
        public bool IsAvailable { get; set; }

        public LibraryItem(int id, string Title)
        {
            this.Id = id;
            this.Title = Title;
            this.IsAvailable = true;
        }

        public abstract void DisplayInfo();
    }
}