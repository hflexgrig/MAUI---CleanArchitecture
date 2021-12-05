using MAUI.CleanArchitecture.Application.MainModel.Queries;
using MAUI.CleanArchitecture.Domain;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private int _count = 0;
        public MainPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private string _currentCount;

        public string CurrentCount
        {
            get => _currentCount;
            set { _currentCount = value; }
        }

        private IList<SubItem> _subItgems;

        public IList<SubItem> SubItems
        {
            get => _subItgems;
            set { _subItgems = value; OnPropertyChanged(); }
        }



        public ICommand CounterClickedCommand => new Command(() => CounterClickedHandlerAsync(), () => true);

        private async void CounterClickedHandlerAsync()
        {
            var mm = await _mediator.Send(new GetMainModelQuery());
            SubItems = mm.SubItems;
            CurrentCount = $"Current count: {mm.TotalQuantity}";
        }
    }
}
