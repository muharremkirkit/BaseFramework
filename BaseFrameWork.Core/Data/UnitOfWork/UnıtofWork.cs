﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseFrameWork.Core.Data.Repository;

namespace BaseFrameWork.Core.Data.UnitOfWork
{
    public class UnıtofWork : IUnıtofWork
    {
        private readonly DbContext context;
        private Dictionary<Type, object> repositories;
        public UnıtofWork(DbContext _context)
        {
            context = _context;
            repositories = repositories ?? new Dictionary<Type, object>();
        }
        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            var repository = new RepositoryBase<T>(context);
            repositories.Add(typeof(T), repository);
            return repository;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }


    }
}
