using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "Mail alanı zorunludur.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yaş alanı zorunludur.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Description { get; set; }
    }
}
