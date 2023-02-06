using INStore.Domain.Models;

namespace INStore.State.UserStore
{
    public interface IInRegistrationUser
    {
        User RegisteringUser { get; set; }
    }
}