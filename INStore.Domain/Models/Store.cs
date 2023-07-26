using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace INStore.Domain.Models
{
    public enum Currency
    {
        EGP,
        USD,
        Euro,
        SAR,
        JPY,
        GBP,
        AUD,
        CAD,
        CHF,
        CNY
    }
    public enum StoreReceiptSize
    {
        [Display(Name = "80")]
        Eighty,
        [Display(Name = "50")]
        Fifty,
    }
    public class Store : DomainObject
    {
        public string StoreName { get; set; } = "";
        public string StorePhoneNumber { get; set; } = "";
        public Currency StoreCurrency { get; set; } = Currency.EGP;
        public StoreReceiptSize storeReceiptSize { get; set; } = StoreReceiptSize.Eighty;
        public int StoreBarCodeLength { get; set; }
    }
}
