using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.EntityLayer.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } /*= null!;*/
        public bool Status { get; set; } 
    }
}
