using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;

        public CategoryController(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.GetList();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Kategoriler Bulunamadı.");
            }
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            var values = _categoryService.GetById(id);
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Aranılan Kategori Bulunamadı.");
            }
        }

        [HttpDelete("DeleteCatgory")]
        public IActionResult DeleteCatgory(int id)
        {
            var values = _categoryService.Delete(id);
            if (values)
            {
                var bookValues = _bookService.GetAllBooksByCategory(id);
                if (bookValues != null)
                {
                    foreach (var item in bookValues)
                    {
                        _bookService.Delete(item);
                        return Ok("Kategori ve bu kategoriye ait kitaplar silindi.");
                    }
                }
                return Ok("Kategori silindi.");

            }
            else
            {
                return BadRequest("Silme İşlemi Başarısız.");
            }
        }

        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            var values = _categoryService.Update(category);
            if (values)
            {
                return Ok("Güncelleme İşlemi Başarılı.");
            }
            else
            {
                return BadRequest("Güncelleme İşlemi Başarısız.");
            }
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(Category category)
        {
            var values=_categoryService.Insert(category);
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
