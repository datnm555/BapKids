namespace BapKids.Domain.Entities
{
    public class Product : BaseEntity
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
