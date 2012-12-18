using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class Person : IEntity
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public EJobTitle JobTitle { get; set; }
      public List<Session> Sessions { get; set; }

      public override string ToString()
      {
         return Name;
      }
   }
}
