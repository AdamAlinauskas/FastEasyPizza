using System.Collections.Generic;
using DataAccess;
using Dto;
using System.Linq;

namespace Service
{
    public interface IPizzaQuery
    {
        IEnumerable<PizzaDto> AllPizzas();
    }

    public class PizzaQuery : IPizzaQuery
    {
        private readonly IPizzaRepository pizzaRepository;

        public PizzaQuery(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        public IEnumerable<PizzaDto> AllPizzas()
        {
            return pizzaRepository.All().Select(x => new PizzaDto{Name = x.Name,Price = x.Price, Id = x.Id});
        }
    }
}