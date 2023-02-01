﻿using INStore.Domain.Exceptions;
using INStore.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static INStore.Domain.Services.AuthenticationService.IAuthenticationService;

namespace INStore.Domain.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly  IPasswordHasher _passwordhasher;
        private readonly  IUserService _userService;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordhasher)
        {
            _userService = userService;
            _passwordhasher = passwordhasher;
        }

        public async Task<User> LogIn(string UserName, string Password)
        {
            User StoredUser = await _userService.GetByUsername(UserName);
            if (StoredUser == null) 
            {
                throw new UserNotFoundException(UserName); 
            }
            PasswordVerificationResult passwordResult = _passwordhasher.VerifyHashedPassword(StoredUser.PasswordHash, Password);
            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new UserNotFoundException(UserName,Password);
            }
            return StoredUser;
        }

        public async Task<RegistrationResult> Registre(string UserName, string Password, string AdminPassword, string AccountState, string EmployeeName)
        {
            RegistrationResult result = RegistrationResult.Success;
            string HashedPassword = _passwordhasher.HashPassword(Password);
            string HashedAdminPassword = _passwordhasher.HashPassword(AdminPassword);


            User UserNameCheck = await _userService.GetByUsername(UserName);
            if (UserNameCheck != null) 
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            User AdminPasswordCheck = await _userService.GetByUsername(HashedAdminPassword);
            if (AdminPassword != "excELI")
            {
                if (AdminPasswordCheck == null)
                {
                    result = RegistrationResult.AdminPasswordDoNotMatch;
                }

            }

            if (result == RegistrationResult.Success)    
            {
                User user = new User()
                {
                    UserName = UserName,
                    PasswordHash = HashedPassword,
                    AdminPasswordHash = HashedAdminPassword,
                    AccountState = AccountState,
                    EmployeeName = EmployeeName
                };
                await _userService.Create(user);
                
            }
            return result;
        }
        }
    }