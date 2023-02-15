using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using INStore.State.Authenticators;
using INStore.State.Navigators;

namespace INStore.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {
        private readonly IAuthenticators authenticators;
        private readonly IRenavigator loginRenavigator;
        ICommand RenavigatToLogin;
        public LogoutCommand(IAuthenticators authenticators, IRenavigator loginRenavigator ) 
        {
            this.authenticators = authenticators;
            this.loginRenavigator = loginRenavigator;
            RenavigatToLogin = new RenavigateCommand(this.loginRenavigator);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            authenticators.Logout();
            RenavigatToLogin.Execute(parameter);
        }
    }
}
