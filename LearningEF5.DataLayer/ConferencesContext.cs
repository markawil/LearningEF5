using System.Data.Entity;

namespace LearningEF5.DataLayer
{
   public class ConferencesContext<TEntity> : DbContext where TEntity : class
   {
      public DbSet<TEntity> Set { get; set; }
   }
}