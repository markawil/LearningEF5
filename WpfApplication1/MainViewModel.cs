using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Domain;
using LearningEF5.DataLayer;

namespace WpfApplication1
{
   public class MainViewModel : PropertyChangedBase, IMainViewModel
   {
      private BindableCollection<Person> _persons;
      private BindableCollection<Session> _selectedPersonSessions;
      private BindableCollection<Session> _sessionsAvailable;
      private IEnumerable<EJobTitle> _jobTitles;
      private EJobTitle _selectedJobTitle;
      private string _name;
      private string _sessionName;
      private bool _isWorkshop;

      // dependencies
      private readonly IRepository<Person> _personRepository;
      private readonly IRepository<Session> _sessionRepository;
      private readonly IRepository<Workshop> _workshopRepository;
      private Person _selectedPerson;
      private Session _selectedSession;

      public MainViewModel(IRepository<Person> personRepository,
         IRepository<Session> sessionRepository,
         IRepository<Workshop> workshopRepository)
      {
         _personRepository = personRepository;
         _sessionRepository = sessionRepository;
         _workshopRepository = workshopRepository;
         _name = "Enter name here";
      }

      public BindableCollection<Person> Persons
      {
         get { return _persons; }
         set { _persons = value; }
      }

      public Person SelectedPerson
      {
         get { return _selectedPerson; }
         set { _selectedPerson = value; }
      }

      public BindableCollection<Session> SelectedPersonSessions
      {
         get { return _selectedPersonSessions; }
         set { _selectedPersonSessions = value; }
      }

      public BindableCollection<Session> SessionsAvailable
      {
         get { return _sessionsAvailable; }
         set { _sessionsAvailable = value; }
      }

      public Session SelectedSession
      {
         get { return _selectedSession; }
         set { _selectedSession = value; }
      }

      public IEnumerable<EJobTitle> JobTitles
      {
         get
         {
            return Enum.GetValues(typeof(EJobTitle))
             .Cast<EJobTitle>();
         }
         set { _jobTitles = value; }
      }

      public EJobTitle SelectedJobTitle
      {
         get { return _selectedJobTitle; }
         set { _selectedJobTitle = value; }
      }

      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      public string SessionName
      {
         get { return _sessionName; }
         set { _sessionName = value; }
      }

      public bool IsWorkshop
      {
         get { return _isWorkshop; }
         set { _isWorkshop = value; }
      }

      public void AddSessionOrWorkshop()
      {
         Session newSession;

         if (_isWorkshop)
         {
            newSession = new Workshop
                            {
                               Title = _sessionName
                            };
         }
         else
         {
            newSession = new Session()
                            {
                               Title = _sessionName
                            };
         }

         _sessionRepository.Save(newSession);
         SessionsAvailable.Add(newSession);

         MessageBox.Show("Session saved!");
      }

      public void AddPerson()
      {
         if (_selectedSession == null)
         {
            MessageBox.Show("Select a session to start with.");
            return;
         }

         var sessions = new List<Session>();
         sessions.Add(_selectedSession);
         
         var newPerson = new Person
                            {
                               JobTitle = _selectedJobTitle,
                               Name = _name,
                               Sessions = sessions
                            };

         newPerson.Id = _personRepository.Save(newPerson);
         Persons.Add(newPerson);
         MessageBox.Show("new person saved!");
      }
   }
}