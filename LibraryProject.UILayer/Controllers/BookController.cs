using LibraryProject.DtoLayer.Dtos.AuthorDtos;
using LibraryProject.DtoLayer.Dtos.BookDtos;
using LibraryProject.DtoLayer.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace LibraryProject.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5001/api/Book/GetAllBooks");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBook()
        {
            SetViewBagData().Wait();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBookDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Book/CreateBook", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Book");
                }
                SetViewBagData().Wait();
                return View();
            }
            SetViewBagData().Wait();
            return View();

        }


        public async Task<IActionResult> DeleteBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5001/api/Book/DeleteBook?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5001/api/Book/GetBookById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookDto>(jsonData);
                SetViewBagData().Wait();
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookDto updateBookDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBookDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5001/api/Book/UpdateBook", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Book");
                }
                SetViewBagData().Wait();
                return View();
            }
            SetViewBagData().Wait();
            return View();
        }

        public async Task SetViewBagData()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageCategory = await client.GetAsync("http://localhost:5001/api/Category/GetAllCategories");
            var responseMessageAuthor = await client.GetAsync("http://localhost:5001/api/Author/GetAllAuthors");
            var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
            var jsonDataAuthor = await responseMessageAuthor.Content.ReadAsStringAsync();
            var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
            var authorValues = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonDataAuthor);

            List<SelectListItem> categoryList = categoryValues.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();

            List<SelectListItem> authorList = authorValues.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();

            ViewBag.CategoryValues = categoryList;
            ViewBag.AuthorValues = authorList;
        }
    }
}
