using System.Data.Entity;
using Domain;

namespace LearningEF5.DataLayer
{
   public class WorkshopRepository : Repository<Workshop>
   {
      public WorkshopRepository(DbContext context) : base(context)
      { }
   }
}