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
      private static IRepository<GenderType> _genderRepo;
      private static ConferencesContext _context;
 
      static void Main(string[] args)
      {
         viewExistingData();
         //runInitProgram();
      }

      private static void viewExistingData()
      {
         initRepos();

         PrettyPrintPersonDetails();
      }

      private static void initRepos()
      {
         _context = new ConferencesContext();
         _genderRepo = new GenderRepository(_context);
         _personRepo = new PersonRepository(_context);
         _sessionRepo = new SessionRepository(_context);
         _workshopRepo = new WorkshopRepository(_context);
      }

      private static void runInitProgram()
      {
         Database.SetInitializer(new DropCreateDatabaseAlways<ConferencesContext>());

         initRepos();

         AddGenders();
         AddSessions();
         AddSWDev();
         AddFemaleSWDev();
         AddDBAdmin();
         OutPutPersonAndSessions();
         PrettyPrintPersonDetails();
      }

      private static void AddGenders()
      {
         var male = new GenderType();
         male.Description = "Male";
         var female = new GenderType();
         female.Description = "Female";

         _genderRepo.Save(male);
         _genderRepo.Save(female);
      }


      private static void PrettyPrintPersonDetails()
      {
         Console.WriteLine("-------------------------------\r\n");
         var persons = _personRepo.GetAll();

         foreach (var person in persons)
         {
           // Console.WriteLine("Person was: {0}, Gender was {1}", person.Name, person.Gender.Description);
            Console.WriteLine("Person was {0}", person.Name);
            foreach (var session in person.Sessions)
            {
               Console.WriteLine("Session: {0}", session.Session.Title);
            }
         }

         Console.ReadKey();
      }

      private static void AddDBAdmin()
      {
         GenderType gender = _genderRepo.GetAll().SingleOrDefault(d => d.Description == "Male");
         var newPerson = new Person
         {
            Name = "Bob B",
            Gender = gender
         };

         var sessionsForPerson = new List<PersonSession>();

         var session1 = _sessionRepo.Retrieve(2);

         sessionsForPerson.Add(new PersonSession
                                  {
                                     Session = session1,
                                     Person = newPerson
                                  });

         newPerson.Sessions = sessionsForPerson;
         _personRepo.Save(newPerson);
         Console.WriteLine("Saved a DB Admin!");
      }

      private static void AddFemaleSWDev()
      {
         GenderType gender = _genderRepo.GetAll().SingleOrDefault(d => d.Description == "Female");
         var newPerson = new Person
         {
            Name = "Sally C",
            Gender = gender
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
         Console.WriteLine("Saved a Software Dev!");
      }

      private static void AddSWDev()
      {
         GenderType gender = _genderRepo.GetAll().SingleOrDefault(d => d.Description == "Male");
         var newPerson = new Person
                            {
                               Name = "Mark W",
                               Gender = gender
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
         Console.WriteLine("Saved a Software Dev!");
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
      }
   }
}
