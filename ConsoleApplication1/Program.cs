using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using LearningEF5.DataLayer;

namespace ConsoleApplication1
{
   class Program
   {
      private static IRepository<Person> _personRepo;
      private static IRepository<Session> _sessionRepo;
      private static IRepository<Workshop> _workshopRepo;

      static void Main(string[] args)
      {
         _personRepo = new Repository<Person>();
         _sessionRepo = new Repository<Session>();
         _workshopRepo = new Repository<Workshop>();

         AddSessions();
         AddPerson();
         OutPutPersonAndSessions();
      }

      private static void AddPerson()
      {
         var sessionsForPerson = new List<Session>();

         var session1 = _sessionRepo.Retrieve(1);
         var session2 = _sessionRepo.Retrieve(2);
         sessionsForPerson.Add(session1);
         sessionsForPerson.Add(session2);

         var newPerson = new Person
                            {
                               JobTitle = EJobTitle.SoftwareDeveloper,
                               Name = "Mark Wilkinson",
                               Sessions = sessionsForPerson
                            };

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
         var person = _personRepo.Retrieve(0);
         var sessions = person.Sessions;

         Console.WriteLine("Person was: {0}", person.Name);

         foreach (var session in sessions)
         {
            Console.WriteLine(session.Title);
         }
      }
   }
}
