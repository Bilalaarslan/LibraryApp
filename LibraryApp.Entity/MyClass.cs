using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity
{
    public class MyClass:BaseEntity
    {
        public string ClassName { get; set; }

        [ValidateNever]
        public List<Student>Students  { get; set; }
    }

  
}

