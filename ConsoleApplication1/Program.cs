using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using LearningEF5.DataLayer;
using System.Data.Entity;

namespace ConsoleApplication1
{
   class Program
   {
      private static IRepository<Person> _personRepo;
      private static IRepository<Session> _sessionRepo;
      private static IRepository<Workshop> _workshopRepo;

      static void Main(string[] args)
      {
         Database.SetInitializer(new DropCreateDatabaseAlways<ConferencesContext>());

         _personRepo = new PersonRepository();
         _sessionRepo = new SessionRepository();
         _workshopRepo = new WorkshopRepository();

         AddSessions();
         AddPerson();
         OutPutPersonAndSessions();
      }

      private static void AddPerson()
      {

         var newPerson = new Person
                            {
                               JobTitle = EJobTitle.SoftwareDeveloper,
                               Name = "Mark W",
                            };

         var sessionsForPerson = new List<PersonSession>();

         var session1 = _sessionRepo.Retrieve(1);
         var session2 = _sessionRepo.Retrieve(2);

         sessionsForPerson.Add(new PersonSession
                                  {
                                     Session = session1,
                                     Person = newPerson,
                                  });

         sessionsForPerson.Add(new PersonSession
                                  {
                                     Session = session2,
                                     Person = newPerson,
                                  });

         newPerson.Sessions = sessionsForPerson;


         _personRepo.Save(newPerson);
         Console.WriteLine("Saved new person!");
      }

      private static void AddSessions()
      {
         var newSession = new Session
                             {
                                StartTime = DateTime.Now,
                                Title = "ObjC for CS devs"
                             };

         var newSession2 = new Workshop
                              {
                                 StartTime = DateTime.Now.AddMinutes(2),
                                 Title = "Entity Framework 2"
                              };

         var newSession3 = new Session
                              {
                                 StartTime = DateTime.Now.AddMinutes(2),
                                 Title = "MongoDB"
                              };

         _sessionRepo.Save(newSession);
         _sessionRepo.Save(newSession2);
         _sessionRepo.Save(newSession3);


         Console.WriteLine("Saved new sessions!");
      }
      
      private static void OutPutPersonAndSessions()
      {
         var person = _personRepo.Retrieve(1);
         var sessions = person.Sessions;

         Console.WriteLine("Person was: {0}", person.Name);

         foreach (var personSession in sessions)
         {
            Console.WriteLine(personSession.Session.Title);
         }

         Console.WriteLine("Sessions available:");

         var sessionsAvailable = _sessionRepo.GetAll().ToList();

         foreach (var session in sessionsAvailable)
         {
            Console.WriteLine(session.Title);
         }

         Console.ReadKey();
      }
   }
}
