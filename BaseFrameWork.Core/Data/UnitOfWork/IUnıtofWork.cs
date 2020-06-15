using BaseFrameWork.Core.Data.Repository;
using System;

namespace BaseFrameWork.Core.Data.UnitOfWork
{
   public interface IUnıtofWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}
