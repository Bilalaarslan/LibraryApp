using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.ViewsModels
{
    public class WriterDetailsVM
    {
        public string? WriterFullName { get; set; }

        public string CategoryName { get; set; }
        public string BookName { get; set; }

        public int Point { get; set; }

        public int NumberOfPage { get; set; }


    }
}
