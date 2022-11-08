namespace INStore.Domain.Models
{
    public class Settings : DomainObject
    {
        public bool? ChangeAccountinfo { get; set; }
        public bool? AddDeleteItems { get; set; }
        public bool? ViewMYStore { get; set; }
        public bool? ViewEmployeeInfo { get; set; }
        public bool? ViewVendorsAndCustomersInfo { get; set; }
        public bool? ViewSettings { get; set; }
        public bool? ViewDashboard { get; set; }
        public bool? ViewTools { get; set; }
        public bool? MakeRefund { get; set; }
        public bool? CancelOrders { get; set; }

    }
}
