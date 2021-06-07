using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Retail.ViewModels.InventoryStock
{
    public class InventoryStockViewModel : BaseViewModel
    {
        public InventoryStockViewModel(INavigation navigation) : base(navigation)
        {
            InventoryStockDetails.Add(new InventoryStockDetailsList { TargetDate = DateTime.Now, TargetModelName = "NA-F130A5WRN", Quantity = "20", Amount = "20,000 AED" });
            InventoryStockDetails.Add(new InventoryStockDetailsList { TargetDate = DateTime.Now, TargetModelName = "KA-F155A5WRN", Quantity = "50", Amount = "15,000 AED" });
            InventoryStockDetails.Add(new InventoryStockDetailsList { TargetDate = DateTime.Now, TargetModelName = "MA-F250A5WRN", Quantity = "60", Amount = "25,000 AED" });
            InventoryStockDetails.Add(new InventoryStockDetailsList { TargetDate = DateTime.Now, TargetModelName = "BA-F250A5WRN", Quantity = "60", Amount = "25,000 AED" });

        }

        public ObservableCollection<InventoryStockDetailsList> InventoryStockDetails { get; set; } =
          new ObservableCollection<InventoryStockDetailsList>();
    }
}


public class InventoryStockDetailsList
{
    public DateTime TargetDate { get; set; }
    public string TargetModelName { get; set; }
    public string Quantity { get; set; }
    public string Amount { get; set; }
}
