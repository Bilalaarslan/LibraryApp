using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }= Guid.NewGuid();

        public DateTime? DateOfUpdate { get; set; } = DateTime.Now;
        public DateTime? DateOfAdding { get; set; } = DateTime.Now;


    }
}
