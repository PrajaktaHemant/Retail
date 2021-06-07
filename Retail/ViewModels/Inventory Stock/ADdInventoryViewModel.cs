using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Retail.Views.InventoryStock;
using Retail.Views.SalesTargetViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Retail.ViewModels.InventoryStock
{
    public class ADdInventoryViewModel : BaseViewModel
    {
        public ADdInventoryViewModel(INavigation navigation) : base(navigation)
        {
            TotalCount = InventoryLists.Count.ToString();            
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command<InventoryList>(async (item) =>
                {
                    InventoryLists.Remove(item);
                    TotalCount = InventoryLists.Count.ToString();

                });
            }
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new Command(async () =>
                {                    
                    await PopupNavigation.PushAsync(new ConfirmInventoryPopup());
                });
            }
        }

        public Command SearchByCategoryCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.PushAsync(new ProductCategoryPopupView(2));
                });
            }
        }

        public Command RecentlyUsedModelNoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopupNavigation.PushAsync(new RecentlyUsedModelNoPopupView(2));

                });
            }
        }
        public ICommand AddInventoryStock
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        InventoryLists.Add(new InventoryList
                        {
                            ModelNo = ModelNumber,
                            Qty = Quantity,
                            ProductCategoryName = "Washing Machine"
                        });
                       TotalCount = InventoryLists.Count.ToString();
                        
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }

        public ObservableCollection<InventoryList> InventoryLists { get; set; } =
           new ObservableCollection<InventoryList>();

        private bool _IsQtyListVisible;
        public bool IsQtyListVisible
        {
            get { return _IsQtyListVisible; }
            set
            {
                _IsQtyListVisible = value;
                OnPropertyChanged("IsQtyListVisible");
            }
        }


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

        private string _ModelNumber;
        public string ModelNumber

        {
            get { return _ModelNumber; }
            set
            {
                _ModelNumber = value;
                OnPropertyChanged("ModelNumber");
            }
        }

        private string _Quantity;
        public string Quantity

        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                _SelectedDate = value;


                OnPropertyChanged("SelectedDate");
            }
        }

        private InventoryList _SelectedItems;
        public InventoryList SelectedItems
        {
            get { return _SelectedItems; }
            set
            {
                _SelectedItems = value;
                OnPropertyChanged("SelectedItems");
            }
        }
    }

    
}

public class InventoryList
{
    public string ProductCategoryName { get; set; }
    public string ModelNo { get; set; }
    public string Qty { get; set; }    
}
