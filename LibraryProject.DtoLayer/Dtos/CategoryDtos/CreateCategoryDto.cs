using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
    }
}
