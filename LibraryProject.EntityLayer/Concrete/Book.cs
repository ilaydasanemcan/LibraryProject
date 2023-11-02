using LibraryProject.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.EntityLayer.Concrete
{
    public class Book : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public int PageCount { get; set; }
        public decimal Price {  get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
