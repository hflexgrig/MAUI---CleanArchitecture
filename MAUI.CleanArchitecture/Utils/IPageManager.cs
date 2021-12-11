using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Utils
{
    public interface IPageManager
    {
        Task PopPageAsync();
        Task<TViewModel> StartPageAsync<TViewModel>();
    }
}