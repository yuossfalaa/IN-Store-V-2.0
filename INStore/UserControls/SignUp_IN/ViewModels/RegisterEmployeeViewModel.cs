using INStore.Commands;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.UserControls.SignUp_IN.Commands;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class RegisterEmployeeViewModel : ViewModelBase
    {
        private readonly ILogger<RegisterEmployeeViewModel> _RegisterEmployeeViewModelLogger;
        private readonly IRenavigator RegisterRenavigator;
        private readonly IRenavigator LoginRenavigator;
        private readonly IInRegistrationUser _InRegistrationUser;
        private readonly IAuthenticators _Authenticators;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;
        private string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value;
                OnPropertyChanged(nameof(EmployeeName));
                _InRegistrationUser.RegisteringUser.employee.EmployeeName = EmployeeName; }
        }
        private string _EmployeeAddress;

        public string EmployeeAddress
        {
            get { return _EmployeeAddress; }
            set { _EmployeeAddress = value; 
                OnPropertyChanged(nameof(EmployeeAddress));
                _InRegistrationUser.RegisteringUser.employee.EmployeeAddress = EmployeeAddress;
            }
        }
        private string _EmployeeDescription;

        public string EmployeeDescription
        {
            get { return _EmployeeDescription; }
            set { _EmployeeDescription = value;
                OnPropertyChanged(nameof(EmployeeDescription));
                _InRegistrationUser.RegisteringUser.employee.EmployeeDescription = EmployeeDescription;
            }
        }
        private string _EmployeePhoneNumber;

        public string EmployeePhoneNumber
        {
            get { return _EmployeePhoneNumber; }
            set { _EmployeePhoneNumber = value;
                OnPropertyChanged(nameof(EmployeePhoneNumber));
                _InRegistrationUser.RegisteringUser.employee.EmployeePhoneNumber = EmployeePhoneNumber;
            }
        }
        private string _EmployeeJob;

        public string EmployeeJob
        {
            get { return _EmployeeJob; }
            set { _EmployeeJob = value;
                OnPropertyChanged(nameof(EmployeeJob));
                _InRegistrationUser.RegisteringUser.employee.EmployeeJob = EmployeeJob;

            }
        }
        private double _EmployeeSalary;

        public double EmployeeSalary
        {
            get { return _EmployeeSalary; }
            set { _EmployeeSalary = value;
                OnPropertyChanged(nameof(EmployeeSalary));
                _InRegistrationUser.RegisteringUser.employee.EmployeeSalary = EmployeeSalary;

            }
        }
        private DateTime _EmployeeShiftStartsAt;

        public DateTime EmployeeShiftStartsAt
        {
            get { return _EmployeeShiftStartsAt; }
            set { _EmployeeShiftStartsAt = value;
                OnPropertyChanged(nameof(EmployeeShiftStartsAt));
                _InRegistrationUser.RegisteringUser.employee.EmployeeShiftStartsAt = EmployeeShiftStartsAt;

            }
        }
        private DateTime _EmployeeShiftEndsAt;

        public DateTime EmployeeShiftEndsAt
        {
            get { return _EmployeeShiftEndsAt; }
            set { _EmployeeShiftEndsAt = value;
                OnPropertyChanged(nameof(EmployeeShiftEndsAt));
                _InRegistrationUser.RegisteringUser.employee.EmployeeShiftEndsAt = EmployeeShiftEndsAt;

            }
        }

        public ICommand RegisterRenavigatCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public RegisterEmployeeViewModel(ILogger<RegisterEmployeeViewModel> registerEmployeeViewModelLogger, 
            IRenavigator registerRenavigator,
            IRenavigator loginRenavigator,
            IInRegistrationUser inRegistrationUser,
            IAuthenticators authenticators, 
            ISnackbarMessageQueue snackbarMessageQueue)
        {
            _RegisterEmployeeViewModelLogger = registerEmployeeViewModelLogger;
            RegisterRenavigator = registerRenavigator;
            _InRegistrationUser = inRegistrationUser;
            _Authenticators = authenticators;
            this.snackbarMessageQueue = snackbarMessageQueue;
            LoginRenavigator = loginRenavigator;

            RegisterRenavigatCommand = new RenavigateCommand(RegisterRenavigator);
            RegisterCommand = new RegisterCommand(_Authenticators, _InRegistrationUser, LoginRenavigator, snackbarMessageQueue, _RegisterEmployeeViewModelLogger);

            _RegisterEmployeeViewModelLogger.Log(LogLevel.Information, "RegisterEmployeeViewModel Initialized");
        }
    }
}
