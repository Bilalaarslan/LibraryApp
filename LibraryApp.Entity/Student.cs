using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using LibraryApp.Entity.Enums;

namespace LibraryApp.Entity
{
    public class Student:BaseEntity
    {
        
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }

        public GenderType Gender { get; set; }

        public DateTime DateOfBirthStudent { get; set; }

        //Bire Çok ilişkide Foreign Key olması için aşağıdaki property tanımlandı.
        public Guid MyClassId { get; set; }
        [ValidateNever]
        public MyClass MyClass { get; set; }

        [ValidateNever]
        public List<Process> StudentsProcess { get; set; }
    }

    


   

}
