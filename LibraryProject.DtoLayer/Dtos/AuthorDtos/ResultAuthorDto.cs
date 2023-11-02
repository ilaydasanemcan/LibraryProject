using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos.AuthorDtos
{
    public class ResultAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}
