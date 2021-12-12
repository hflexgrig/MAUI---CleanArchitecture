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
        public Task<TViewModel> StartPageAsync<TViewModel>(bool isModal = false)
        {
            return ViewModelLocator.StartPageAsync<TViewModel>(isModal);
        }

        public Task PopPageAsync()
        {
            return ViewModelLocator.PopPageAsync();
        }

        public Task PopToRootPageAsync()
        {
            return ViewModelLocator.PopToRootPageAsync();
        }
    }
}
