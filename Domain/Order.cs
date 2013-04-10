namespace Domain
{
    public class Order : IEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PickUp { get; set; }
        public virtual string Address { get; set; }
        public virtual string Toping1 { get; set; }
        public virtual string Toping2 { get; set; }
        public virtual string Toping3 { get; set; }
        public virtual bool ExtraSauce { get; set; }
        public virtual long Id { get; set; }
    }
}