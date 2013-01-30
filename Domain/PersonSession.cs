namespace Domain
{
   public class PersonSession : IEntity
   {
      public int Id { get; set; }
      public virtual Person Person { get; set; }
      public virtual Session Session { get; set; }
   }
}