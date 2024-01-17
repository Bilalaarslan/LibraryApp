using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity
{
    public class Writer:BaseEntity
    {

        public string? WriterName { get; set; }
        public string? WriterSurname { get; set; }
        public string? WriterFullName
        {
            //Burası ne amaçla yapıldı? Nasıl yapıldı?
            get
            {
                return WriterName + " " + WriterSurname;
            }
        }

        [ValidateNever]
        public List<Book> WritersBooks { get; set; }

    }
}
