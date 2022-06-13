using CarRentalSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Abstract
{
    public interface IEntityRepository<T>where T : class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter);
     
        


    }
}
