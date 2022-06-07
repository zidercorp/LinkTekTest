using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LinkTekTest.Application.Models
{
    public class CustomerModel : INotifyPropertyChanged
    {
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
        private DateTime _createdTime;
        private DateTime _updatedTime;

        public int CustomerId { get; set; }

        public string FirstName
        {
            get => _firstName;
            set 
            {
                _firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }

        public string Address1
        {
            get => _address1;
            set
            {
                _address1 = value;
                NotifyPropertyChanged(nameof(Address1));
            }
        }

        public string Address2
        {
            get => _address2;
            set
            {
                _address2 = value;
                NotifyPropertyChanged(nameof(Address2));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyPropertyChanged(nameof(_city));
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                NotifyPropertyChanged(nameof(State));
            }
        }

        public string Zip
        {
            get => _zip;
            set
            {
                _zip = value;
                NotifyPropertyChanged(nameof(Zip));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                NotifyPropertyChanged(nameof(Age));
            }
        }

        public decimal Sales
        {
            get => _sales;
            set
            {
                _sales = value;
                NotifyPropertyChanged(nameof(Sales));
            }
        }

        public DateTime CreatedTime 
        {
            get => _createdTime;
            set
            {
                _createdTime = value;
                NotifyPropertyChanged(nameof(CreatedTime));
            }
        }

        public DateTime UpdatedTime 
        {
            get => _updatedTime;
            set
            {
                _updatedTime = value;
                NotifyPropertyChanged(nameof(UpdatedTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
