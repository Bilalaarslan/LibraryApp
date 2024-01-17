using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity
{
    public class Process:BaseEntity
    {
        public DateTime GetDate { get; set; }
        public DateTime GiveBackDate { get; set; }

        //Bire Çok ilişkide Foreign Key olması için aşağıdaki property tanımlandı.
        public Guid StudentId { get; set; }

        [ValidateNever]
        public Student Student { get; set; }

        //Bire Çok ilişkide Foreign Key olması için aşağıdaki property tanımlandı.
        public Guid BookId { get; set; }
        [ValidateNever]
        public Book Book { get; set; }

    }

    

}
