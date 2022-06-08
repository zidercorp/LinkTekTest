using AutoMapper;
using MediatR;
using StructureMap;
using System;
using System.Linq;

namespace LinkTekTest.Application
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.AssemblyContainingType<ApplicationRegistry>();
                scanner.AssemblyContainingType<IMediator>();
                scanner.WithDefaultConventions();
                scanner.LookForRegistries();
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();

            var profiles = from t in typeof(ApplicationRegistry).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);

            //For each Profile, include that profile in the MapperConfiguration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            var mapper = config.CreateMapper();

            //Register the DI interfaces with their implementation
            For<IConfigurationProvider>().Use(config);
            For<IMapper>().Use(mapper);
        }
    }
}