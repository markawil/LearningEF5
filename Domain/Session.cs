using System;

namespace Domain
{
   public class Session : IEntity
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public DateTime StartTime { get; set; }

      public override string ToString()
      {
         return Title;
      }
   }
}