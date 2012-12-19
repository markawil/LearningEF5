using Domain;

namespace LearningEF5.DataLayer
{
   public interface ISessionRepository : IRepository<Session>
   {
      
   }

   public class SessionRepository : Repository<Session>
   {

   }
}