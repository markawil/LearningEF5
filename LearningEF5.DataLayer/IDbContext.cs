using System.Data.Entity;
using System.Linq;

namespace LearningEF5.DataLayer
{
   public interface IDbContext
   {
      DbSet<T> GetSet<T>() where T : class;
   }
}