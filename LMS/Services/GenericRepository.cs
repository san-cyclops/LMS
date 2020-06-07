using LMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Services
{
    public class GenericRepository<T> where T : class
    {
        internal LMSDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(LMSDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public void Insert(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            //dbSet.Add(entity);
            //context.Attach(entity);
            //context.Remove(entity);
            //context.SaveChanges();
        }
    }
}
