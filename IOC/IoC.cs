using DataAccess;
using Service;
using StructureMap;

namespace IOC {
    public static class IoC {
        public static StructureMap.IContainer Initialize() {
            ObjectFactory.Initialize(x => x.Scan(scan =>
                {
                    scan.Assembly(typeof(OrderTask).Assembly);
                    scan.Assembly(typeof(OrderRepository).Assembly);
                    scan.Assembly(typeof(OrderRepository).Assembly);
                    scan.WithDefaultConventions();
                }));
            return ObjectFactory.Container;
        }
    }
}