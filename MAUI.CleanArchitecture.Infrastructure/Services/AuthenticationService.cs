using AutoMapper;
using MAUI.CleanArchitecture.Application.Common.Exceptions;
using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Application.User.Commands.Register;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure.Services
{
    public class AuthenticationService : IAuthentication
    {
        readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(RegisterCommand user)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(user);

            var result = await _userManager.CreateAsync(applicationUser);
            if (!result.Succeeded)
            {
                throw new ValidationException("Unable to create user") { ValidationErrors = result.Errors.ToDictionary(x => x.Code, x => x.Description) };
            }

            var loaded = await _userManager.FindByEmailAsync(user.Email);
            return _mapper.Map<User>(loaded);
        }

        public async Task<User> UpdatePassword(string email, string oldPassword, string newPassword)
        {
            var loaded1 = await _userManager.FindByNameAsync(email);
            if (loaded1 == null)
            {
                return null;
            }

            var result = await _userManager.ChangePasswordAsync(loaded1, oldPassword, newPassword);
            if (!result.Succeeded)
            {
                return null;
            }

            var loaded = await _userManager.FindByNameAsync(email);
            return _mapper.Map<User>(loaded);
        }

        public async Task<bool> CheckPassword(string email, string password)
        {
            var loaded1 = await _userManager.FindByNameAsync(email);
            if (loaded1 == null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(loaded1, password);
        }
    }
}
