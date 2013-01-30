using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Domain;

namespace LearningEF5.DataLayer
{
   public abstract class Repository<T> : IDisposable, IRepository<T> where T : class, IEntity
   {
      protected readonly DbContext _context;

      protected Repository(DbContext context)
      {
         _context = context;
      }

      public virtual void Delete(int id)
      {
         T t = _context.Set<T>().Find(id);

         _context.Set<T>().Remove(t);
         _context.SaveChanges();
      }

      public virtual bool Exists(int id)
      {
         var t = _context.Set<T>().Find(id);
         return t != null;
      }

      public virtual T Retrieve(int id)
      {
         return _context.Set<T>().Find(id);
      }

      public virtual IEnumerable<T> GetAll()
      {
         return _context.Set<T>();
      }

      public virtual int Save(T t)
      {
         if (t.Id == 0)
            _context.Entry(t).State = EntityState.Added;
         else
            _context.Entry(t).State = EntityState.Modified;

         _context.SaveChanges();
         return t.Id;
      }

      public void Dispose()
      {
         _context.Dispose();
      }
   }
}