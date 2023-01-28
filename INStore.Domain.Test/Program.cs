using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.EntityFramework;
using INStore.EntityFramework.Services;
namespace Program
{
    class Program
    {
        static void Main (string[] args)
        {
            IDataService<User> user = new GenericDataService<User>(new INStoreDbContextFactory());
            Console.WriteLine(user.GetAll().Result);
            Console.ReadLine ();
        }
    }


}