namespace JLDatabase.Database.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}