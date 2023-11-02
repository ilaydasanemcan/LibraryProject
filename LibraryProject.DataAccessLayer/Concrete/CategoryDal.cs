using Dapper;
using LibraryProject.DataAccessLayer.Abstract;
using LibraryProject.DataAccessLayer.Concrete.DapperContext;
using LibraryProject.DtoLayer.Dtos.CategoryDtos;
using LibraryProject.EntityLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace LibraryProject.DataAccessLayer.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        private readonly Context _context;

        public CategoryDal(Context context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            string query = "insert into Categories (Name,Status) values(@Name,@Status)";
            var parameters = new DynamicParameters();
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, entity);

            }
        }

        public List<Category> GetAll()
        {
            string query = "Select * From Categories Where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.Query<Category>(query);
                return values.ToList();
            }
        }

        public Category GetById(int Id)
        {
            string query = "Select * From Categories Where Id= @Id";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<Category>(query, new { Id = Id });
                return value;
            }
        }

        public void Update(Category entity)
        {
            string query = "Update Categories SET Name=@Name Where Id=@Id and Status=1";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, entity);
            }
        }

        public void Remove(int Id)
        {
            string query = "Update Categories SET Status=0 Where Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { Id = Id });
            }
        }
    }
}
