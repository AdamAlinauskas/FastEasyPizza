using System;
using DataAccess;
using Service;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace IOC {
    public static class IoC {
        public static StructureMap.IContainer Initialize() {
            ObjectFactory.Initialize(x => x.Scan(scan =>
                {
                    scan.Assembly(typeof(PizzaTask).Assembly);
                    scan.Assembly(typeof(PizzaRepository).Assembly);
                    scan.WithDefaultConventions();
                    scan.Convention<PerRequest>();         
                }));

            ObjectFactory.WhatDoIHave();
//            ObjectFactory.Container.EjectAllInstancesOf<IDatabaseUnitOfWork>();
//            var structureMapDependencyResolver = new StructureMap.(container);

            return ObjectFactory.Container;
        }
    }

    public class PerRequest : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if(type == typeof(IDatabaseUnitOfWork))
                registry.For(type).HttpContextScoped();
        }
    }
}