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
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public bool Delete(int id)
        {
            var value = _authorDal.GetById(id);
            if (value is null)
            {
                
                return false;
            }
            _authorDal.Remove(id);
            return true;

        }

        public Author GetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public List<Author> GetList()
        {
            return _authorDal.GetAll();
        }

        public bool Insert(Author entity)
        {
            _authorDal.Add(entity);
            return true;
        }

        public bool Update(Author entity)
        {
            var value = _authorDal.GetById(entity.Id);
            if (value is null)
            {
                
                return false;
            }
            _authorDal.Update(entity);
            return true;
        }
    }
}
