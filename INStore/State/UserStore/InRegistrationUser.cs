using INStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.State.UserStore
{
    public class InRegistrationUser : IInRegistrationUser
    {
        public User RegisteringUser { get; set; }
        public InRegistrationUser()
        {
            RegisteringUser = new User();
            RegisteringUser.Employee = new Employee();
        }
    }
}
