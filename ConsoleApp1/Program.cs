using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.EntityFramework;
using INStore.EntityFramework.Services;
using System.Security.AccessControl;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Users> userService = new GenericDataService<Users>(new INStoreDbContextFactory());
            userService.Create(new Users { UserName = "test" }).Wait();
        }
    }
}
