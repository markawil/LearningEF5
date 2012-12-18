namespace Domain
{
   public class Workshop : Session, IEntity
   {
      public int ID { get; set; }
      public string Description { get; set; }
   }
}