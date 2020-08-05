using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGenericService<T>where T:class,ITable,new()
    {
        Task<List<T>> GetAll();       
        Task<T> GetById(int Id);       
        Task Update(T entity);
        Task Add(T entity);
        Task Remove(T entity);
    }
}
