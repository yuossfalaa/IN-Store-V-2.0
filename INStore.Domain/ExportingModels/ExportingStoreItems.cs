using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.Domain.ExportingModels
{
    public class ExportingStoreItems
    {
        public string Item_Name { get; set; } = "";
        public string Item_Description { get; set; } = "";
        public string Item_BarCode { get; set; } = "";
        public double Item_Selling_Price { get; set; } = 0.0;
        public double Item_Purchasing_Price { get; set; } = 0.0; 
        public int Item_Number_InStore { get; set; } = 0;
        public int Item_Number_InStock { get; set; } = 0;

    }
}
