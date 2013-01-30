using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
   public class Person : IEntity
   {
      public int Id { get; set; }
      [MaxLength(10)]
      public string Name { get; set; }
      public virtual GenderType Gender { get; set; }
      public virtual List<PersonSession> Sessions { get; set; }

      public override string ToString()
      {
         return Name;
      }
   }
}
