﻿using INStore.Domain.Models;
using INStore.Domain.Services.AuthenticationService;
using INStore.State.UserStore;
using System;
using System.Threading.Tasks;

namespace INStore.State.Authenticators
{
    public interface IAuthenticators
    {
        User CurrentUser { get; set; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task Login(string UserName, string Password);
        void Logout();
        Task<IAuthenticationService.RegistrationResult> Register(IInRegistrationUser inRegistrationUser);
    }
}