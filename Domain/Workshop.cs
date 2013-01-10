using System.ComponentModel.DataAnnotations;

namespace Domain
{
   public class Workshop : Session
   {
      public string Description { get; set; }

      public override string ToString()
      {
         return base.ToString() + "*";
      }
   }
}