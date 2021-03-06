using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OB.Data.Repositories
{
    public class BaseRepository<T> where T : class
    {
        //--------------------------------------------------------------------------
        private DataContext db { get; set; }
        protected DbSet<T> DbSet { get; set; }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
        public BaseRepository(DataContext context)
        {
            db = context;
            DbSet = db.Set<T>();
        }

        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
        public int Count()
        {
            return DbSet.Count();
        }
        //--------------------------------------------------------------------------
        public virtual bool Exists(int Id)
        {
            var item = DbSet.Find(Id);
            db.Entry(item).State = EntityState.Detached;
            return (item != null);
        }
        //--------------------------------------------------------------------------
        public virtual List<T> ListAll()
        {
            return DbSet.AsNoTracking().ToList();
        }
        //--------------------------------------------------------------------------
        public async virtual Task<List<T>> ListAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        //--------------------------------------------------------------------------
        public virtual T GetById(int Id)
        {
            return DbSet.Find(Id);
        }
        //--------------------------------------------------------------------------
        public async virtual Task<T> GetByIdAsync(int Id)
        {
            return await DbSet.FindAsync(Id);
        }
        //--------------------------------------------------------------------------
        public virtual T GetByIdDetached(int Id)
        {
            var item = DbSet.Find(Id);
            db.Entry(item).State = EntityState.Detached;
            return item;
        }
        //--------------------------------------------------------------------------
        public virtual T Add(T entity)
        {
            EntityEntry dbEnitityEntry = db.Entry(entity);
            if (dbEnitityEntry.State != EntityState.Detached)
            {
                dbEnitityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
            return entity;
        }
        //--------------------------------------------------------------------------
        public virtual async Task<T> AddAsync(T entity)
        {
            return await Task<T>.Run(() =>
            {
                EntityEntry dbEnitityEntry = db.Entry(entity);
                if (dbEnitityEntry.State != EntityState.Detached)
                {
                    dbEnitityEntry.State = EntityState.Added;
                }
                else
                {
                    DbSet.Add(entity);
                }
                return entity;
            });
        }
        //--------------------------------------------------------------------------
        public virtual T Update(T entity)
        {
            EntityEntry dbEnitityEntry = db.Entry(entity);
            if (dbEnitityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEnitityEntry.State = EntityState.Modified;
            return entity;
        }
        //--------------------------------------------------------------------------
        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await Task<T>.Run(() =>
            {
                EntityEntry dbEnitityEntry = db.Entry(entity);
                if (dbEnitityEntry.State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                dbEnitityEntry.State = EntityState.Modified;
                return entity;
            });
        }
        //--------------------------------------------------------------------------
        public virtual void Delete(T entity)
        {
            EntityEntry dbEnitityEntry = db.Entry(entity);
            if (dbEnitityEntry.State != EntityState.Deleted)
            {
                dbEnitityEntry.State = EntityState.Deleted;
            }
        }
        //--------------------------------------------------------------------------
        public virtual async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                EntityEntry dbEnitityEntry = db.Entry(entity);
                if (dbEnitityEntry.State != EntityState.Deleted)
                {
                    dbEnitityEntry.State = EntityState.Deleted;
                }
            });
        }
        //--------------------------------------------------------------------------
    }
}