using Caliburn.Micro;
using Domain;
using LearningEF5.DataLayer;

namespace WpfApplication1
{
   public class MainViewModel : PropertyChangedBase, IMainViewModel
   {
      private BindableCollection<string> _persons;
      private BindableCollection<string> _selectedPersonSessions;
      private BindableCollection<string> _sessionsAvailable;
      private BindableCollection<string> _jobTitles;
      private string _selectedJobTitle;
      private string _name;
      private string _sessionName;
      private bool _isWorkshop;

      // dependencies
      private readonly IRepository<Person> _personRepository;
      private readonly IRepository<Session> _sessionRepository;
      private readonly IRepository<Workshop> _workshopRepository;
 
      public MainViewModel(IRepository<Person> personRepository,
         IRepository<Session> sessionRepository,
         IRepository<Workshop> workshopRepository)
      {
         _personRepository = personRepository;
         _sessionRepository = sessionRepository;
         _workshopRepository = workshopRepository;
         _name = "Enter name here";
      }

      public BindableCollection<string> Persons
      {
         get { return _persons; }
         set { _persons = value; }
      }

      public BindableCollection<string> SelectedPersonSessions
      {
         get { return _selectedPersonSessions; }
         set { _selectedPersonSessions = value; }
      }

      public BindableCollection<string> SessionsAvailable
      {
         get { return _sessionsAvailable; }
         set { _sessionsAvailable = value; }
      }

      public BindableCollection<string> JobTitles
      {
         get { return _jobTitles; }
         set { _jobTitles = value; }
      }

      public string SelectedJobTitle
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
   }

   public interface IMainViewModel
   {
      BindableCollection<string> Persons { get; set; }
      BindableCollection<string> SelectedPersonSessions { get; set; }
      BindableCollection<string> SessionsAvailable { get; set; }
      BindableCollection<string> JobTitles { get; set; }
      string SelectedJobTitle { get; set; }
      string Name { get; set; }
      string SessionName { get; set; }
      bool IsWorkshop { get; set; }
   }
}