using StructureMap;

namespace IOC {
    public static class IoC {
        public static StructureMap.IContainer Initialize() {
            ObjectFactory.Initialize(x => x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                }));
            return ObjectFactory.Container;
        }
    }
}