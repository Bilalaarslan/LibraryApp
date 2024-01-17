using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity
{
    public class Book:BaseEntity
    {
        public string IsbnNo { get; set; }
        public string BookName { get; set; }

        public int NumberOfPage { get; set; }

        public int Point { get; set; }

        //Bire çok ilişkide tablolar arası bağlantı için aşağıdaki (foreignname) tanımlamak için kullanıldı.
        public Guid WriterId { get; set; }

        [ValidateNever]
        public Writer Writer { get; set; }

        //Bire çok ilişkide tablolar arası bağlantı için aşağıdaki (foreignname) tanımlamak için kullanıldı.
        public Guid CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public List<Process> BooksProcess { get; set; }

    }
}
    
