using System.Collections.Generic;
using System.Data;
using Domain;

namespace LearningEF5.DataLayer
{
   public class Repository<T> : IRepository<T> where T : class, IEntity
   {
      private readonly ConferencesContext<T> _context = new ConferencesContext<T>();
 
      public void Delete(int id)
      {
         T t = _context.Set.Find(id);
         _context.Set.Remove(t);
         _context.SaveChanges();
      }

      public bool Exists(int id)
      {
         var t = _context.Set.Find(id);
         return t != null;
      }

      public T Retrieve(int id)
      {
         return _context.Set.Find(id);
      }

      public IEnumerable<T> GetAll()
      {
         return _context.Set;
      }

      public int Save(T t)
      {
         if (t.ID == 0)
            _context.Entry(t).State = EntityState.Added;
         else
            _context.Entry(t).State = EntityState.Modified;

         _context.SaveChanges();
         return t.ID;
      }
   }
}