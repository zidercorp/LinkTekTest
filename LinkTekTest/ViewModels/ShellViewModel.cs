using Caliburn.Micro;
using StructureMap;
using System.Windows.Controls;

namespace LinkTekTest.ViewModels
{
    public class ShellViewModel : Screen
    {
        private INavigationService navigationService;
        private readonly IContainer _container;
        public ShellViewModel(IContainer container)
        {
            _container = container;

        }

        public void RegisterFrame(Frame frame)
        {
            navigationService = new FrameAdapter(frame);

            _container.Configure(c =>
            {
                c.For<INavigationService>().Add(navigationService);
            });

            navigationService.NavigateToViewModel(typeof(MainViewModel));
        }
    }
}
