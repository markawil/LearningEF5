using System.Data.Entity;
using Domain;

namespace LearningEF5.DataLayer
{
   public class GenderRepository : Repository<GenderType>
   {
      public GenderRepository(DbContext context) : base(context)
      { }
   }
}