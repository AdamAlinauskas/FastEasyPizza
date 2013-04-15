using System.Collections.Generic;
using Domain;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace DataAccess
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> All();
    }

    public class PizzaRepository : IPizzaRepository
    {
        private readonly IDatabaseUnitOfWork unitOfWork;

        public PizzaRepository(IDatabaseUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Save(Pizza pizza)
        {
            
                unitOfWork.Session.Save(pizza);
             
        }

        public IEnumerable<Pizza> FindAllPizzas()
        {
            ISession session = new DatabaseSessionFactory().Create();
            return session.Query<Pizza>().Where(x => x.Price == 10);
        }

        public IEnumerable<Pizza> All()
        {
            return unitOfWork.Session.Query<Pizza>().ToList();
        }
    }
}