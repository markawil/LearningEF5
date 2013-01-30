using System.Data.Entity;
using System.Linq;

namespace LearningEF5.DataLayer
{
   public interface IDbContext
   {
      DbSet<T> Set<T>() where T : class;
   }
}