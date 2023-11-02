using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BussinessLayer.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        List<int> GetAllBooksByAuthor(int authorId);
        List<int> GetAllBooksByCategory(int categoryId);
    }
}
