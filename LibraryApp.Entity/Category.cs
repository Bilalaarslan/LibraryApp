﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        [ValidateNever]
        public List<Book> BooksCategory { get; set; }
    }
}
