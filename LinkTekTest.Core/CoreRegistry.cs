using LinkTekTest.Core.Repositories.Base;
using StructureMap;

namespace LinkTekTest.Core
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            //Scan(scanner =>
            //{
            //    scanner.TheCallingAssembly();
            //    scanner.WithDefaultConventions();
            //    scanner.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
            //    scanner.LookForRegistries();
            //});
        }
    }
}