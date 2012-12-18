using System.Collections.Generic;
using Caliburn.Micro;
using Domain;

namespace WpfApplication1
{
   public interface IMainViewModel
   {
      BindableCollection<Person> Persons { get; set; }
      Person SelectedPerson { get; set; }
      BindableCollection<Session> SelectedPersonSessions { get; set; }
      BindableCollection<Session> SessionsAvailable { get; set; }
      Session SelectedSession { get; set; }
      IEnumerable<EJobTitle> JobTitles { get; set; }
      EJobTitle SelectedJobTitle { get; set; }
      string Name { get; set; }
      string SessionName { get; set; }
      bool IsWorkshop { get; set; }
      void AddSessionOrWorkshop();
      void AddPerson();
   }
}