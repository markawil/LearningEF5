using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Domain
{
   public class Session : IEntity
   {
      [Key]
      public int Id { get; set; }
      public string Title { get; set; }
      public DateTime StartTime { get; set; }

      public override string ToString()
      {
         return Title;
      }
   }
}