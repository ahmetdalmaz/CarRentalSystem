using CarRentalSystem.DataAccess.Abstract;
using CarRentalSystem.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class,IEntity,new()
    {

        public void Add(TEntity entity)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
               

            }
           
        }

        public void Delete(TEntity entity)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (CarRentalContext db = new())
            {
                return db.Set<TEntity>().FirstOrDefault(filter);
            }
            
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                return filter == null ?  db.Set<TEntity>().ToList()
                : db.Set<TEntity>().Where(filter).ToList();

            }
  
            
            
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                return filter == null ? await db.Set<TEntity>().ToListAsync()
                : await db.Set<TEntity>().Where(filter).ToListAsync();

            }
        }

        public void Update(TEntity entity)
        {
            using (CarRentalContext db = new CarRentalContext())
            {
                db.Set<TEntity>().Update(entity);
                db.SaveChanges();

            }
        }
    }
}
