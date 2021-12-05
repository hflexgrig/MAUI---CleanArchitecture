using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Utils
{
    public interface IPageManager
    {
        Task<bool> StartPage<TViewModel>();
    }
}