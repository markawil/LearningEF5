using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
