﻿using AutoMapper;
using MAUI.CleanArchitecture.Application.Common.Exceptions;
using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Application.User.Commands.Login;
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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(RegisterCommand registerCommand)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(registerCommand);

            var result = await _userManager.CreateAsync(applicationUser);
            if (!result.Succeeded)
            {
                throw new ValidationException("Unable to create user") { ValidationErrors = result.Errors.ToDictionary(x => x.Code, x => x.Description) };
            }

            var loaded = await _userManager.FindByEmailAsync(registerCommand.Email);
            return _mapper.Map<User>(loaded);
        }

        public async Task<User> SignInAsync(LoginCommand loginCommand)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(loginCommand);

            var result = await _signInManager.PasswordSignInAsync(loginCommand.Username, loginCommand.Password, true, true);
            if (!result.Succeeded)
            {
                throw new ValidationException("Unable to create user") { ValidationErrors = result.IsLockedOut 
                    ? new Dictionary<string, string> { { "fail", "locked out"} } 
                    : new Dictionary<string, string> { { "fail", "wrong username or password" } }
                };
            }

            var loaded = await _userManager.FindByEmailAsync(loginCommand.Username);
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
