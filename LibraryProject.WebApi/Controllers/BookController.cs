using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var values = _bookService.GetList();
            if (values is null)
            {
                return NotFound("Kitaplar Bulunamadı.");
            }
            return Ok(values);
        }

        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            var values = _bookService.GetById(id);
            if (values is null)
            {
                return NotFound("Aranılan Kitap Bulunamadı.");
            }
            return Ok(values);
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var values = _bookService.Delete(id);
            if (!values)
            {
                return BadRequest("Silme İşlemi Başarısız.");
            }
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            var values = _bookService.Update(book);
            if (!values)
            {
                return BadRequest("Güncelleme İşlemi Başarısız.");
            }
            return Ok("Güncelleme İşlemi Başarılı.");
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            var values=_bookService.Insert(book);
            if (!values)
            {
                return BadRequest("Ekleme İşlemi Başarısız.");
            }
            return Ok("Ekleme İşlemi Başarılı.");
        }
    }
}
