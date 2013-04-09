using Domain;

namespace DataAccess
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            
        }
    }
}