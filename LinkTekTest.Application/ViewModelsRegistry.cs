using MediatR;
using StructureMap;

namespace LinkTekTest.Application
{
    public class ViewModelsRegistry : Registry
    {
        public ViewModelsRegistry()
        {
            // MediatR handler registrations
            Scan(s =>
            {
                s.Assembly(this.GetType().Assembly);

                s.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                s.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>));
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();
        }
    }
}