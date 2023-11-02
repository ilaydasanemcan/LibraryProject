using LibraryProject.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.EntityLayer.Concrete
{
    public class Author : BaseEntity
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}
