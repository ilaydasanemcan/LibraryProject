using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.GetList();
            if (values is null)
            {
                return NotFound("Kategoriler Bulunamadı.");
            }
            return Ok(values);
        }

        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            var values = _categoryService.GetById(id);
            if (values is null)
            {
                return NotFound("Aranılan Kategori Bulunamadı.");
                
            }
            return Ok(values);
        }

        [HttpDelete]
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

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var values = _categoryService.Update(category);
            if (!values)
            {
                return BadRequest("Güncelleme İşlemi Başarısız.");
                
            }
            return Ok("Güncelleme İşlemi Başarılı.");
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            var values=_categoryService.Insert(category);
            if (!values)
            {
                return BadRequest("Ekleme İşlemi Başarısız.");
                
            }
            return Ok("Ekleme İşlemi Başarılı.");
        }
    }
}
