using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Truck.Domain.Entities;
using Truck.Domain.Interfaces;
using Truck.Infra.Data;

namespace Truck.Infra.Repository
{
    public class BaseReposytory<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly TruckDbContext _dbContext;
        public BaseReposytory(TruckDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Insert(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(T obj)
        {
            _dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Set<T>().Remove(Select(id));
            _dbContext.SaveChanges();
        }

        public IList<T> Select() => _dbContext.Set<T>().ToList();

        public T Select(int? id) =>
            _dbContext.Set<T>().Find(id);
    }
}
