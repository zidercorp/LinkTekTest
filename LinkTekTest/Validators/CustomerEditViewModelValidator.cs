using FluentValidation;
using LinkTekTest.ViewModels;

namespace LinkTekTest.Validators
{
    public class CustomerEditViewModelValidator : AbstractValidator<CustomerEditViewModel>
    {
        public CustomerEditViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(x => x.Address1).NotNull().NotEmpty().MaximumLength(40);
            RuleFor(x => x.City).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.State).NotNull().NotEmpty().MaximumLength(2);
            RuleFor(x => x.Zip).NotNull().NotEmpty().MaximumLength(10);
            RuleFor(x => x.Phone).NotNull().NotEmpty().MaximumLength(20);
        }
    }
}
