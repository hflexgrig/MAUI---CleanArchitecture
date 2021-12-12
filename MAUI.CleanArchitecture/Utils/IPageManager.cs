using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Utils
{
    public interface IPageManager
    {
        Task PopPageAsync();
        Task PopToRootPageAsync();
        Task<TViewModel> StartPageAsync<TViewModel>(bool isModal = false);
    }
}