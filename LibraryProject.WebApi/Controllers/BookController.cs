using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var values = _bookService.GetList();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Kitaplar Bulunamadı.");
            }
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            var values = _bookService.GetById(id);
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Aranılan Kitap Bulunamadı.");
            }
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            var values = _bookService.Delete(id);
            if (values)
            {
                return Ok("Silme İşlemi Başarılı");
            }
            else
            {
                return BadRequest("Silme İşlemi Başarısız.");
            }
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Book book)
        {
            var values = _bookService.Update(book);
            if (values)
            {
                return Ok("Güncelleme İşlemi Başarılı.");
            }
            else
            {
                return BadRequest("Güncelleme İşlemi Başarısız.");
            }
        }

        [HttpPost("CreateBook")]
        public IActionResult CreateBook(Book book)
        {
            var values=_bookService.Insert(book);
            if (values)
            {
                return Ok("Ekleme İşlemi Başarılı.");
            }
            else
            {
                return BadRequest("Ekleme İşlemi Başarısız.");
            }
        }
    }
}
