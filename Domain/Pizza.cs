namespace Domain
{
    public class Pizza : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }

        public Pizza()
        {
            Id = 0;
        }
    }
}