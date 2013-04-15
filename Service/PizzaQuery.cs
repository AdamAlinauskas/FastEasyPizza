using System.Collections.Generic;
using DataAccess;
using System.Linq;
using Dto;

namespace Service
{
    public interface IPizzaQuery
    {
        IEnumerable<PizzaListingDto> AllPizzas();
    }

    public class PizzaQuery : IPizzaQuery
    {
        private readonly IPizzaRepository pizzaRepository;

        public PizzaQuery(IPizzaRepository pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        public IEnumerable<PizzaListingDto> AllPizzas()
        {
            return pizzaRepository.All().Select(x => new PizzaListingDto{Name = x.Name,Price = x.Price, Id = x.Id});
        }
    }
}