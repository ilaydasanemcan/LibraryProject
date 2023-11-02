using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.BussinessLayer.Abstract
{
    public interface IGenericService<TEntity>
    {
        List<TEntity> GetList();
        TEntity GetById(int id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
    }
}
