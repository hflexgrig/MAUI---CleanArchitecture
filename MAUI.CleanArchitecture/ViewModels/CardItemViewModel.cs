using MAUI.CleanArchitecture.Application.Card.Commands.CreateCardItem;
using MAUI.CleanArchitecture.Application.Common.Notificications;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class CardItemViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public CardItemViewModel(IServiceProvider serviceProvider)
        {
            AddToCardCommand = new Command((obj) => AddToCardHandler(), (obj) => CardItem.Quantity > 0);
            _serviceProvider = serviceProvider;
            _mediator = _serviceProvider.GetService<IMediator>();
        }

        private async void AddToCardHandler()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    await mediator.Send(new CreateCardItemCommand { CardItem = CardItem });
                }

                await _mediator.Publish(new AddCardItemNotification { CardItem = CardItem });
            }
            catch (Exception ex)
            {
                //TODO: Show user facing
            }
        }

        public int Quantity
        {
            get { return CardItem.Quantity; }
            set
            {
                CardItem.Quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CardItem.CalculatedPrice));
                AddToCardCommand.ChangeCanExecute();
            }
        }

        public string CalculatedPrice => CardItem.CalculatedPrice.ToString();

        public CardItem CardItem { get; set; } = new CardItem();
        public Command AddToCardCommand { get; }
    }
}
