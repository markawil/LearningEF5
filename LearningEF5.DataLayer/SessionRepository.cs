using System.Data.Entity;
using Domain;

namespace LearningEF5.DataLayer
{
   public class SessionRepository : Repository<Session>
   {
      public SessionRepository(DbContext context) : base(context)
      { }
   }
}