using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.models;

namespace LibraryApp
{
    internal class Library<T> where T : LibraryItem<T>
    {
        List<T> items = new List<T>();  
    }
}
