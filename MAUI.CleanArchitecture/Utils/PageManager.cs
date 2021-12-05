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
        public Task<bool> StartPage<TViewModel>()
        {
            return ViewModelLocator.StartPage<TViewModel>();
        }
    }
}
