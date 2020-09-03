using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Core.Entity;
using YemekSepeti.Core.Service;
using YemekSepeti.Model.Context;

namespace YemekSepeti.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private static YSContext _context;

        public YSContext context
        {
            get
            {
                if (_context == null)
                    _context = new YSContext();
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public bool Add(T item)
        {
            context.Set<T>().Add(item);
            return Save() > 0;
        }

        public bool Add(List<T> items)
        {
            context.Set<T>().AddRange(items);
            return Save() > 0;
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Any(exp);
            //return Save() > 0;
        }

        public List<T> GetActive()
        {
            return context.Set<T>().Where(x => x.Status == Core.Entity.Enum.Status.Active || x.Status == Core.Entity.Enum.Status.Updated || x.Status == Core.Entity.Enum.Status.None).ToList();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetbyID(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            item.Status = Core.Entity.Enum.Status.Deleted;
            return Update(item);
        }

        public bool Remove(Guid id)
        {
            T item = context.Set<T>().Find(id);
            item.Status = Core.Entity.Enum.Status.Deleted;
            DbEntityEntry entry = context.Entry(item);
            entry.CurrentValues.SetValues(item);
            return Save() > 0;
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            var x = GetDefault(exp);
            int recordCount = x.Count;
            int successCount = 0;
            foreach (var item in x)
            {
                item.Status = Core.Entity.Enum.Status.Deleted;
                bool i = Update(item);
                if (i) successCount++;
            }
            if (successCount == recordCount) return true;
            else return false;

        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Update(T item)
        {
            T updated = GetbyID(item.ID);
            item.Status = Core.Entity.Enum.Status.Updated;
            DbEntityEntry entry = context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            return Save() > 0;
        }

        public void DetachEntity(T item)
        {
            context.Entry<T>(item).State = System.Data.Entity.EntityState.Detached;
        }
    }
}
