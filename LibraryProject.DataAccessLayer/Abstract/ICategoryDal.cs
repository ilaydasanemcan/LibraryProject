using LibraryProject.DtoLayer.Dtos.CategoryDtos;
using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {

    }
}
