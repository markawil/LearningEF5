namespace Domain
{
   public class PersonSession : IEntity
   {
      public int Id { get; set; }
      public Person Person { get; set; }
      public Session Session { get; set; }
   }
}