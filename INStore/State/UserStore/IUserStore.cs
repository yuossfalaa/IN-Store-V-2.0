using INStore.Domain.Models;
using System;

namespace INStore.State.UserStore
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }

        event Action StateChanged;
    }
}