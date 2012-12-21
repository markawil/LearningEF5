using System.Collections.Generic;

namespace LearningEF5.DataLayer
{
   public interface IRepository<T>
   {
      void Delete(int id);
      bool Exists(int id);
      T Retrieve(int id);
      IEnumerable<T> GetAll();
      int Save(T t);
   }
}
