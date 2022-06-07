using Caliburn.Micro;
using FluentValidation;
using LinkTekTest.Application.Commands;
using LinkTekTest.Application.Models;
using LinkTekTest.Messages;
using MediatR;
using System.Threading;
using System.Windows;

namespace LinkTekTest.ViewModels
{
    public class CustomerEditViewModel : Screen
    {
        private readonly IMediator _mediator;
        private readonly IEventAggregator _eventAggregator;
        private readonly IValidator<CustomerEditViewModel> _validator;

        private string _firstName;
        private string _lastName;
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private string _zip;
        private string _phone;
        private int _age;
        private decimal _sales;
        private bool _isDirty = false;

        public CustomerEditViewModel(IMediator mediator, IEventAggregator eventAggregator, IValidator<CustomerEditViewModel> validator, CustomerModel customer)
        {
            _mediator = mediator;
            _eventAggregator = eventAggregator;
            _validator = validator;

            SetProperties(customer);
        }

        private void SetProperties(CustomerModel customer)
        {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Address1 = customer.Address1;
            Address2 = customer.Address2;
            City = customer.City;
            State = customer.State;
            Zip = customer.Zip;
            Phone = customer.Phone;
            Age = customer.Age;
            Sales = customer.Sales;
        }

        public int CustomerId { get; set; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                var changed = Set(ref _firstName, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                var changed = Set(ref _lastName, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string Address1
        {
            get => _address1;
            set
            {
                var changed = Set(ref _address1, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string Address2
        {
            get => _address2;
            set
            {
                var changed = Set(ref _address2, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string City
        {
            get => _city;
            set
            {
                var changed = Set(ref _city, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string State
        {
            get => _state;
            set
            {
                var changed = Set(ref _state, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string Zip
        {
            get => _zip;
            set
            {
                var changed = Set(ref _zip, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                var changed = Set(ref _phone, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                var changed = Set(ref _age, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }

        public decimal Sales
        {
            get => _sales;
            set
            {
                var changed = Set(ref _sales, value);

                if (changed)
                {
                    _isDirty = true;
                }
            }
        }


        public async void Save()
        {
            var result = _validator.Validate(this);
            
            if (result.IsValid)
            {
                var updatedCustomer = await _mediator.Send(new UpdateCustomerCommand
                {
                    CustomerId = CustomerId,
                    FirstName = FirstName,
                    LastName = LastName,
                    Address1 = Address1,
                    Address2 = Address2,
                    City = City,
                    State = State,
                    Zip = Zip,
                    Phone = Phone,
                    Age = Age,
                    Sales = Sales
                });

                if (updatedCustomer == null)
                {
                    MessageBox.Show("Failed updating customer.", "An error as occurred", MessageBoxButton.OK);
                }

                await _eventAggregator.PublishOnUIThreadAsync(new UpdatedCustomerMessage(updatedCustomer), CancellationToken.None);

                await TryCloseAsync();
            }
            else
            {
                MessageBox.Show("Please complete customer details", "Validation Failed", MessageBoxButton.OK);
            }
        }

        public async void Cancel()
        {
            if (_isDirty)
            {
                var result = MessageBox.Show("There has been changes on this customer, do you want to continue?", "Cancel Edit", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    await TryCloseAsync();
                    return;
                }
            }
            else
            {
                await TryCloseAsync();
            }
        }
    }
}
