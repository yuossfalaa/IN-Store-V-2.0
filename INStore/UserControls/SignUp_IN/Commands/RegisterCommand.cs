using INStore.Commands;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.UserControls.SignUp_IN.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
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
        private readonly ISnackbarMessageQueue snackbarMessageQueue;
        ILogger<RegisterEmployeeViewModel> logger;
        public RegisterCommand(IAuthenticators authenticators, IInRegistrationUser inRegistrationUser, 
            IRenavigator renavigator, ISnackbarMessageQueue snackbarMessageQueue, 
            ILogger<RegisterEmployeeViewModel> logger)
        {
            this.authenticators = authenticators;
            this.inRegistrationUser = inRegistrationUser;
            this.renavigator = renavigator;
            this.snackbarMessageQueue = snackbarMessageQueue;
            this.logger = logger;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                RegistrationResult result = RegistrationResult.Success;

                result = await authenticators.Register(inRegistrationUser);
                if (result == RegistrationResult.Success)
                {
                    renavigator.Renavigate();
                }
                else if (result == RegistrationResult.AdminPasswordDoNotMatch)
                {
                    snackbarMessageQueue.Enqueue("Wrong Admin Password");
                    logger.LogTrace("Wrong Admin Password");

                }
                else if (result == RegistrationResult.UsernameAlreadyExists)
                {
                    snackbarMessageQueue.Enqueue("Username Already Exists");
                    logger.LogTrace("Username Already Exists");

                }
            }
            catch(Exception excption)
            {
                logger.LogError(excption.Message);
            }
     
        }
    }
}
