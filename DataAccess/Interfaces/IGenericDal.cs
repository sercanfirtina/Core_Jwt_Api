using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericDal<T>where T:class,ITable,new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter);
        Task<T> GetById(int Id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);
        Task Update(T entity);
        Task Add(T entity);
        Task Remove(T entity);
    }


}
