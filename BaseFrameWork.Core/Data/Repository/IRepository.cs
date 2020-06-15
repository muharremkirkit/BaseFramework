using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseFrameWork.Core.Data.Repository
{
   public interface IRepository<T> where T: class
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T,bool>> filter = null); //lampda expression metodunu kullanmak için func ile tanımladık

        IQueryable<T> GetAll(); //nokta atışı sorgu yapabilmemizi sağlar.toplu şekilde getirebiliriz
        
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes); //birden fazla expression metodunu her yerde kullanabiliriz çünkü object alır
        //methodun parametre sayısı bilinmezse params kullanılır.çok sayıda parametli alabilir.

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, 
                          Expression<Func<T, object>> include = null);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
                          Expression<Func<T, object>> include = null,
                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                          int? skip = null,
                          int? take = null              
            );


    }
}
