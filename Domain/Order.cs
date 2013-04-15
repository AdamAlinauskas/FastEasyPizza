using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order : IEntity
    {
        public virtual IList<Pizza> Pizzas { get; set; }
        public virtual long Id { get; set; }
        public virtual DateTime? Date { get; set; }
    }
}