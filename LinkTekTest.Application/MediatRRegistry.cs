using LinkTekTest.Application;
using LinkTekTest.Core.Entities;
using MediatR;
using StructureMap;

namespace LinkTekTest.Application
{
    public class MediatRRegistry : Registry
    {
        public MediatRRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.AssemblyContainingType<MediatRRegistry>();
                scanner.AssemblyContainingType<IMediator>();
                scanner.WithDefaultConventions();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICancellableAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(ICancellableAsyncNotificationHandler<>));
                scanner.LookForRegistries();
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();
        }
    }
}