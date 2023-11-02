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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public bool Delete(int id)
        {
            var value = _categoryDal.GetById(id);
            if (value is null)
            {
                return false;
            }
            _categoryDal.Remove(id);
            return true;
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetAll();
        }

        public bool Insert(Category entity)
        {
            _categoryDal.Add(entity);
            return true;
        }

        public bool Update(Category entity)
        {
            var value = _categoryDal.GetById(entity.Id);
            if (value is null)
            {
                return false;
                
            }
            _categoryDal.Update(entity);
            return true;

        }
    }
}
