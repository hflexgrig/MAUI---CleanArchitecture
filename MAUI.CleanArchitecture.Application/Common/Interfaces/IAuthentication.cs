using MAUI.CleanArchitecture.Application.User.Commands.Register;

namespace MAUI.CleanArchitecture.Application.Common.Interfaces
{
    public interface IAuthentication
    {
        Task<bool> CheckPassword(string email, string password);
        Task<Domain.Entities.User> CreateUser(RegisterCommand registerCommand);
        Task<Domain.Entities.User> UpdatePassword(string email, string oldPassword, string newPassword);
    }
}