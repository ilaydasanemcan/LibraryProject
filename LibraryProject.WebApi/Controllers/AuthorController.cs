using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var values = _authorService.GetList();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Yazarlar Bulunamadı.");
            }
        }

        [HttpGet]
        public IActionResult GetAuthorById(int id)
        {
            var values = _authorService.GetById(id);
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Aranılan Yazar Bulunamadı.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            var values = _authorService.Delete(id);
            if (values)
            {
                var bookValues = _bookService.GetAllBooksByAuthor(id);
                if(bookValues != null)
                {
                    foreach (var item in bookValues)
                    {
                        _bookService.Delete(item);
                    }
                    return Ok("Yazar ve Yazara ait kitaplar silindi.");
                }
                return Ok("Yazar silindi.");

            }
            else
            {
                return BadRequest("Silme İşlemi Başarısız.");
            }
        }

        [HttpPut]
        public IActionResult UpdateAuthor(Author author)
        {
            var values = _authorService.Update(author);
            if (!values)
            {
                
                return BadRequest("Güncelleme İşlemi Başarısız.");
            }
            return Ok("Güncelleme İşlemi Başarılı.");
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            var values = _authorService.Insert(author);
            if (!values)
            {
                
                return BadRequest("Ekleme İşlemi Başarısız.");
            }
            return Ok("Ekleme İşlemi Başarılı.");
        }
    }
}
