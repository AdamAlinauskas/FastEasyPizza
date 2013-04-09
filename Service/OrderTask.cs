using DataAccess;
using Domain;
using Dto;

namespace Service
{
    public interface IOrderTask
    {
        void ProcessOrder(OrderDto dto);
    }

    public class OrderTask : IOrderTask
    {
        private readonly IOrderRepository orderRepository;

        public OrderTask(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void ProcessOrder(OrderDto dto)
        {
            orderRepository.Save(new Order
                {
                    Address = dto.Address,
                    ExtraSauce = dto.ExtraSauce,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                    PickUp = dto.PickUp,
                    Toping1 = dto.Toping1,
                    Toping2 = dto.Toping2,
                    Toping3 = dto.Toping3
                });
        }
    }

    
}