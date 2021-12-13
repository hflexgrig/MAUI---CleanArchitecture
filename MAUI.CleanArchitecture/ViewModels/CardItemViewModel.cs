using MAUI.CleanArchitecture.Application.Common.Notificications;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
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

        public CardItemViewModel(IMediator mediator)
        {
            AddToCardCommand = new Command((obj) => AddToCardHandler(), (obj) => CardItem.Quantity > 0);
            _mediator = mediator;
        }

        private void AddToCardHandler()
        {
            _mediator.Publish(new AddCardItemNotification { CardItem = CardItem});
        }

        public int Quantity
        {
            get { return CardItem.Quantity; }
            set
            {
                CardItem.Quantity = value;
                OnPropertyChanged(nameof(CardItem.CalculatedPrice));
                AddToCardCommand.ChangeCanExecute();
            }
        }

        public string CalculatedPrice => CardItem.CalculatedPrice.ToString();

        public CardItem CardItem { get; set; } = new CardItem();
        public Command AddToCardCommand { get; }
    }
}
