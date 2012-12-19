using System.Data;
using Domain;

namespace LearningEF5.DataLayer
{
   public interface IPersonRepository : IRepository<Person>
   {
      
   }

   public class PersonRepository : Repository<Person>
   {
      public override int Save(Person person)
      {
         if (person.Id == 0)
         {
            _context.Entry(person).State = EntityState.Added;

            foreach (var personSession in person.Sessions)
            {
               if (personSession.Session.Id > 0)
               {
                  _context.Entry(personSession.Session).State = EntityState.Unchanged;
               }
            }
         }
         else
            _context.Entry(person).State = EntityState.Modified;

         _context.SaveChanges();
         return person.Id;
      }
   }
}