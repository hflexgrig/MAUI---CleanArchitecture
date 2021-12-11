using MAUI.CleanArchitecture.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Utils
{
    public class PageManager : IPageManager
    {
        public Task<TViewModel> StartPageAsync<TViewModel>()
        {
            return ViewModelLocator.StartPageAsync<TViewModel>();
        }

        public Task PopPageAsync()
        {
            return ViewModelLocator.PopPageAsync();
        }
    }
}
