using Dapper;
using LibraryProject.DataAccessLayer.Abstract;
using LibraryProject.DataAccessLayer.Concrete.DapperContext;
using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccessLayer.Concrete
{
    public class AuthorDal : IAuthorDal
    {
        private readonly Context _context;

        public AuthorDal(Context context)
        {
            _context = context;
        }

        public void Add(Author entity)
        {
            string query = "insert into Authors (Name,Status,Description,Email,Age) values(@Name,@Status,@Description,@Email,@Age)";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, entity);
            }
        }

        public List<Author> GetAll()
        {
            string query = "Select * From Authors where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.Query<Author>(query);
                return values.ToList();
            }
        }

        public Author GetById(int Id)
        {
            string query = "Select * From Authors Where Id=@Id and Status=1";
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<Author>(query, new {Id=Id});
                return value;
            }
        }

        public void Remove(int Id)
        {
            string query= "Update Authors SET Status=0 Where Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<bool>(query, new { Id = Id });
            }
        }

        public void Update(Author entity)
        {
            string query = "Update Authors SET Name=@Name,Description=@Description,Age=@Age, Email=@Email Where Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<bool>(query, entity);
            }

        }
    }
}
