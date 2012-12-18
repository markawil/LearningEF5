using System;

namespace Domain
{
   public class Session : IEntity
   {
      public int ID { get; set; }
      public string Title { get; set; }
      public DateTime StartTime { get; set; }
   }
}