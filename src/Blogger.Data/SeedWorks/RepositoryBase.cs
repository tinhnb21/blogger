﻿using Blogger.Core.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blogger.Data.SeedWorks
{
    public class RepositoryBase<T, Key> : IRepository<T, Key> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected readonly BloggerContext _context;

        public RepositoryBase(BloggerContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public void Add(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Key id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            _dbSet.RemoveRange(entites);
        }
    }
}
