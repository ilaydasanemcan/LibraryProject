using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos.AuthorDtos
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mail alanı zorunludur.")]
        public string Email { get; set; }

        public bool Status { get; set; } = true;

        [Required(ErrorMessage = "Yaş alanı zorunludur.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Description { get; set; }
    }
}
