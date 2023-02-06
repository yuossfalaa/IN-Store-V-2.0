using INStore.Commands;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static INStore.Domain.Services.AuthenticationService.IAuthenticationService;

namespace INStore.UserControls.SignUp_IN.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly IAuthenticators authenticators;
        private readonly IInRegistrationUser inRegistrationUser;
        private readonly IRenavigator renavigator;

        public RegisterCommand(IAuthenticators authenticators, IInRegistrationUser inRegistrationUser, IRenavigator renavigator)
        {
            this.authenticators = authenticators;
            this.inRegistrationUser = inRegistrationUser;
            this.renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            RegistrationResult result = RegistrationResult.Success;

            result = await authenticators.Register(inRegistrationUser);
            if (result == RegistrationResult.Success)
            {
                renavigator.Renavigate();
            }
        }
    }
}
