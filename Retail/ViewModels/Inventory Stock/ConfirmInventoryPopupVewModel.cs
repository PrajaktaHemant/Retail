using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Retail.ViewModels.InventoryStock
{
    public class ConfirmInventoryPopupVewModel : BaseViewModel
    {
        public ConfirmInventoryPopupVewModel(INavigation navigation ): base(navigation)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    InventoryLists.Add(new InventoryList
                    {
                        ModelNo = "MX-12345" + i,
                        Qty = "10"+i,
                        ProductCategoryName = "Washing Machine"
                    });

                    TotalCount = i.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public ObservableCollection<InventoryList> InventoryLists { get; set; } =
          new ObservableCollection<InventoryList>();

        private string _TotalCount;
        public string TotalCount
        {
            get { return _TotalCount; }
            set
            {
                _TotalCount = value;
                OnPropertyChanged("TotalCount");
            }
        }

    }
}

