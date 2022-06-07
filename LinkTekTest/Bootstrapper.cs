using Caliburn.Micro;
using LinkTekTest.Application;
using LinkTekTest.Application.Handlers.QueryHandlers;
using LinkTekTest.Application.Queries;
using LinkTekTest.Core;
using LinkTekTest.Core.Entities;
using LinkTekTest.Core.Repositories;
using LinkTekTest.Infrastructure.Data;
using LinkTekTest.Infrastructure.Repositories;
using LinkTekTest.ViewModels;
using MediatR;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace LinkTekTest
{
    public class Bootstrapper : BootstrapperBase
    {
        private Container _container;
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void Configure()
        {
            ConfigureIocContainer();

            if (!Execute.InDesignMode)
            {
                ConfigureIocContainer();
            }
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message, "An error as occurred", MessageBoxButton.OK);
        }

        private void ConfigureIocContainer()
        {
            _container = new Container(GetStructureMapConfig);
        }

        private void GetStructureMapConfig(ConfigurationExpression cfg)
        {
            cfg.For<IWindowManager>().Use<WindowManager>().Singleton();
            cfg.For<LinkTekTestContext>().Use(new LinkTekTestContext());
            cfg.For<ICustomerRepository>().Use<CustomerRepository>().Singleton();
            cfg.For<IAsyncRequestHandler<GetAllCustomerQuery, List<Customer>>>().Use<GetAllCustomerHandler>().Singleton();
            cfg.Scan(s =>
            {
                s.AssemblyContainingType<CoreRegistry>();
                s.AssemblyContainingType<MediatRRegistry>();
                s.LookForRegistries();
            });
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).OfType<object>();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            if (serviceType == null) serviceType = typeof(object);
            var returnValue = key == null
                    ? _container.GetInstance(serviceType) : _container.GetInstance(serviceType, key);
            return returnValue;
        }
    }
}
