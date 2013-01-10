using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
   public class Person : IEntity
   {
      public int Id { get; set; }
      [MaxLength(10)]
      public string Name { get; set; }
      public EJobTitle JobTitle { get; set; }
      public List<PersonSession> Sessions { get; set; }

      public override string ToString()
      {
         return Name;
      }
   }
}
