using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DtoLayer.Dtos.BookDtos
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi alanı zorunludur.")]
        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; } = true;

        [Required(ErrorMessage = "Sayfa sayısı alanı zorunludur.")]
        public int? PageCount { get; set; }

        [Required(ErrorMessage = "Ücret alanı zorunludur.")]
        public decimal? Price { get; set; }
        public string CategoryId { get; set; }
        public string AuthorId { get; set; }
    }
}
