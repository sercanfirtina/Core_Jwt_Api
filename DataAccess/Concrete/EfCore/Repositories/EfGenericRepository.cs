using DataAccess.Concrete.EfCore.Context;
using DataAccess.Interfaces;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T:class,ITable,new ()
    {

        public async Task Add(T entity)
        {
            using var context = new JwtContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            using var context = new JwtContext();
           return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new JwtContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new JwtContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(int Id)
        {
            using var context = new JwtContext();
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task Remove(T entity)
        {
            using var context = new JwtContext();
             context.Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task Update(T entity)
        {
            using var context = new JwtContext();
            context.Update(entity);
            await context.SaveChangesAsync();         

        }
    }
}
