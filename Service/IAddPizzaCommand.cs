using DataAccess;
using Domain;
using Dto;

namespace Service
{
    public interface IAddPizzaCommand
    {
        void Execute(PizzaDto dto);
    }

    public class AddPizzaCommand : IAddPizzaCommand
    {
        private readonly IPizzaRepository pizzaRepository;

        public AddPizzaCommand(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        public void Execute(PizzaDto dto)
        {
            pizzaRepository.Save(new Pizza{Name = dto.Name,Price = dto.Price});
        }
    }
}