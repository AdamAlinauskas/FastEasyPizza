using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace DataAccess.MappingConventionsAndOverrides
{
    public class OrderMappingOverride : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.HasManyToMany(x => x.Pizzas);
        }
    }
}