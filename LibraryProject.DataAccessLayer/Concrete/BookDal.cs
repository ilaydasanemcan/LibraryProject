using Dapper;
using LibraryProject.DataAccessLayer.Abstract;
using LibraryProject.DataAccessLayer.Concrete.DapperContext;
using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccessLayer.Concrete
{
    public class BookDal : IBookDal
    {
        private readonly Context _context;

        public BookDal(Context context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            string query = "insert into Books (Name,Status,Price,PageCount,AuthorId,CreateDate,CategoryId) values(@Name,@Status,@Price,@PageCount,@AuthorId,@CreateDate,@CategoryId)";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, entity);
            }
        }

        public List<Book> GetAll()
        {
            string query = "Select * From Books where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.Query<Book>(query);
                return values.ToList();
            }
        }

        public List<int> GetAllBooksByAuthor(int authorId)
        {
            string query = "Select * From Books where Status=1 and AuthorId=@AuthorId";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.Query<int>(query, new { AuthorId = authorId });
                return values.ToList();
            }
        }

        public List<int> GetAllBooksByCategory(int categoryId)
        {
            string query = "Select * From Books where Status=1 and CategoryId=@CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.Query<int>(query, new { CategoryId = categoryId });
                return values.ToList();
            }
        }

        public Book GetById(int Id)
        {
            string query = "Select * From Books Where Id= @Id and Status=1";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<Book>(query, new { Id = Id });
                return value;
            }
        }

        public void Remove(int Id)
        {
            string query = "Update Books SET Status=0 Where Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { Id = Id });
            }
        }

        public void Update(Book entity)
        {
            string query = "Update Books SET Name=@Name,Price=@Price,PageCount=@PageCount,AuthorId=@AuthorId,CreateDate=@CreateDate,CategoryId=@CategoryId  Where Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, entity);
            }
        }

    }
}
