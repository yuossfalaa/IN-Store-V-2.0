using INStore.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.Domain.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<User> LogIn(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Registre(string UserName, string Password, string AdminPassword, string AccountState, string EmployeeName)
        {
            IPasswordHasher hasher = new PasswordHasher();
            string HashedPassword = hasher.HashPassword(Password);
            string HashedAdminPassword = hasher.HashPassword(AdminPassword);

            if (AdminPassword == AdminPassword)    
            {
                User user = new User()
                {
                    UserName = UserName,
                    PasswordHash = HashedPassword,
                    AdminPasswordHash = HashedAdminPassword,
                    AccountState = AccountState,
                    EmployeeName = EmployeeName
                };
                return true;
            }
            return false;
        }



        
        }
    }