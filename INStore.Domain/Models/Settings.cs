namespace INStore.Domain.Models
{
    public class Settings : DomainObject
    {
        public bool ChangeAccountInfo { get; set; } = false;
        public bool AddDeleteItems { get; set; } = false;
        public bool ViewMyStore { get; set; } = false;
        public bool ViewEmployeeInfo { get; set; } = false;
        public bool ViewVendorsAndCustomersInfo { get; set; } = false;
        public bool ViewSettings { get; set; } = false;
        public bool ViewDashboard { get; set; } = false;
        public bool ViewTools { get; set; } = false;
        public bool MakeRefund { get; set; } = false;
        public bool CancelOrders { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
