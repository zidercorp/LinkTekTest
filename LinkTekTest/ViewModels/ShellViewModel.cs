using Caliburn.Micro;
using LinkTekTest.Application.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LinkTekTest.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly IMediator _mediator;
        public ShellViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task OnInitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                var test = await _mediator.Send(new GetAllCustomerQuery());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
