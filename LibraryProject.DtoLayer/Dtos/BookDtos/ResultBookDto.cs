using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos.BookDtos
{
    public class ResultBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
