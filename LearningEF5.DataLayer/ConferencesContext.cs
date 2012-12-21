using System.Data.Entity;
using Domain;

namespace LearningEF5.DataLayer
{
   public class ConferencesContext : DbContext
   {
      public DbSet<Person> Persons { get; set; }
   }
}