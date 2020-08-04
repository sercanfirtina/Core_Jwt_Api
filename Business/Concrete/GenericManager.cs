using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, ITable, new()
    {

        private readonly IGenericDal<T>_genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        //asenkron metodn sonuna async belir yani Addasync
        public async Task Add(T entity)
        {
           await _genericDal.Add(entity);
        }

        public async Task<List<T>> GetAll()
        {
          return  await _genericDal.GetAll();
        }

        public  async Task<T> GetById(int Id)
        {
            return await _genericDal.GetById(Id);
        }

        public async Task Remove(T entity)
        {
            await _genericDal.Remove(entity);
        }

        public async Task Update(T entity)
        {
            await _genericDal.Update(entity);
        }
    }
}
