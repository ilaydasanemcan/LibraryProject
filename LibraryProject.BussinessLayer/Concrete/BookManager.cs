using LibraryProject.BussinessLayer.Abstract;
using LibraryProject.DataAccessLayer.Abstract;
using LibraryProject.DataAccessLayer.Concrete;
using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BussinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        private readonly ICategoryDal _categoryDal;
        private readonly IAuthorDal _authorDal;

        public BookManager(IBookDal bookDal, IAuthorDal authorDal, ICategoryDal categoryDal)
        {
            _bookDal = bookDal;
            _authorDal = authorDal;
            _categoryDal = categoryDal;
        }

        public bool Delete(int id)
        {
            var value = _bookDal.GetById(id);
            if (value is null)
            {
                
                return false;
            }
            _bookDal.Remove(id);
            return true;
        }

        public List<int> GetAllBooksByAuthor(int authorId)
        {
            return _bookDal.GetAllBooksByAuthor(authorId);
        }

        public List<int> GetAllBooksByCategory(int categoryId)
        {
            return _bookDal.GetAllBooksByCategory(categoryId);
        }

        public Book GetById(int id)
        {
            return _bookDal.GetById(id);
        }

        public List<Book> GetList()
        {
            return _bookDal.GetAll();
        }

        public bool Insert(Book entity)
        {
            var categoryValue = _categoryDal.GetById(entity.CategoryId);
            var authorValue = _authorDal.GetById(entity.AuthorId);
            if (categoryValue is null && authorValue is null)
            {
                return false;
                
            }
            _bookDal.Add(entity);
            return true;
        }

        public bool Update(Book entity)
        {
            var value = _bookDal.GetById(entity.Id);
            var categoryValue = _categoryDal.GetById(entity.CategoryId);
            var authorValue = _authorDal.GetById(entity.AuthorId);
            if (value is null && categoryValue is null && authorValue is null)
            {
                return false;
            }
            _bookDal.Update(entity);
            return true;
        }
    }
}
