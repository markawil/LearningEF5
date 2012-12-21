using System.ComponentModel.DataAnnotations;

namespace Domain
{
   public class Workshop : Session, IEntity
   {
      public int Id { get; set; }
      public string Description { get; set; }

      public override string ToString()
      {
         return base.ToString() + "*";
      }
   }
}