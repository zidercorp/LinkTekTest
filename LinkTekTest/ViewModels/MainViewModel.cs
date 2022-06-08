using Caliburn.Micro;
using FluentValidation;
using LinkTekTest.Application.Mappers;
using LinkTekTest.Application.Models;
using LinkTekTest.Application.Queries;
using LinkTekTest.Application.Services;
using LinkTekTest.Messages;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LinkTekTest.ViewModels
{
    public class MainViewModel : Screen, IHandle<UpdatedCustomerMessage>
    {
        private readonly IMediator _mediator;
        private readonly IWindowManager _windowManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IValidator<CustomerEditViewModel> _validator;
        private readonly USStateService _stateService;

        private bool _isBusy;

        public MainViewModel(IMediator mediator, 
                             IWindowManager windowManager, 
                             IValidator<CustomerEditViewModel> validator, 
                             IEventAggregator eventAggregator,
                             USStateService stateService)
        {
            _mediator = mediator;
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _validator = validator;
            _stateService = stateService;
            _eventAggregator.SubscribeOnPublishedThread(this);
        }

        public async void LoadAsync()
        {
            IsBusy = true;

            var customers = await _mediator.Send(new GetAllCustomerQuery());

            var customerModels = CustomerMapper.Mapper.Map<IEnumerable<CustomerModel>>(customers);

            Customers = new BindableCollection<CustomerModel>(customerModels);

            IsBusy = false;
        }

        public void RowSelect(CustomerModel customer)
        {
            var dialogViewModel = new CustomerEditViewModel(_mediator, _eventAggregator, _validator, _stateService, customer);
            _windowManager.ShowDialogAsync(dialogViewModel);
        }

        public Task HandleAsync(UpdatedCustomerMessage message, CancellationToken cancellationToken)
        {
            var updatedCustomer = Customers?.FirstOrDefault(x => x.CustomerId == message.Customer.CustomerId);

            if (updatedCustomer != null)
            {
                updatedCustomer.CustomerId = message.Customer.CustomerId;
                updatedCustomer.FirstName = message.Customer.FirstName;
                updatedCustomer.LastName = message.Customer.LastName;
                updatedCustomer.Address1 = message.Customer.Address1;
                updatedCustomer.Address2 = message.Customer.Address2;
                updatedCustomer.City = message.Customer.City;
                updatedCustomer.State = message.Customer.State;
                updatedCustomer.Zip = message.Customer.Zip;
                updatedCustomer.Phone = message.Customer.Phone;
                updatedCustomer.Age = message.Customer.Age;
                updatedCustomer.Sales = message.Customer.Sales;
                updatedCustomer.UpdatedTime = message.Customer.UpdatedTime;
            }

            return Task.FromResult(true);
        }

        private BindableCollection<CustomerModel> _customers;

        public BindableCollection<CustomerModel> Customers
        {
            get => _customers;
            set
            {
                if (_customers == value)
                    return;

                _customers = value;
                NotifyOfPropertyChange(() => Customers);
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }
    }
}
