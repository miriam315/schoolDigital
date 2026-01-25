using Microsoft.EntityFrameworkCore;
using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDigital.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
        public bool Exists(int id)
        {
            return _dbSet.Any(e => e.Id == id);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }


    }
}
