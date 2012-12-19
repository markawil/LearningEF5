using System.ComponentModel.DataAnnotations;

namespace Domain
{
   public class Workshop : Session, IEntity
   {
      [Key]
      public int Id { get; set; }
      public string Description { get; set; }

      public override string ToString()
      {
         return base.ToString() + "*";
      }
   }
}