using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Retail.ViewModels.SalesTarget
{
    public class SalesDataReturnEntryViewModel : BaseViewModel
    {
        public SalesDataReturnEntryViewModel(INavigation navigation) : base(navigation)
        {

        }
        

        public Command SaveReturnEntryCommand
        {
            get
            {
                return new Command(async () =>
                {
                    
                });
            }
        }

        public Command GetSalesTransactionCommand
        {
            get
            {
                return new Command<ModelReturnEntryList>(async (obj) =>
                {
                    try
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ModelReturnEntryLists.Add(new ModelReturnEntryList
                            {
                                ModelNo = "TX6789GH" + i,
                                Qty = "10" + i,
                                Price = "37500" + i,
                                TotalAmount = Convert.ToDouble(Quantity) * Convert.ToDouble(UnitPrice)
                            }) ;
                        }

                        TotalAmount = TotalAmount + (Convert.ToDouble(Quantity) * Convert.ToDouble(UnitPrice));
                       
                    }

                    catch(Exception ex)
                    {

                    }
                });                
            }
        }

        public ICommand AddEntriesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        UpdatedModelReturnEntryLists.Add(new UpdatedModelReturnEntryList
                        {
                            ModelNo = ModelNumber ,
                            Qty = Quantity,
                            Price = UnitPrice,
                            TotalAmount = Convert.ToDouble(Quantity) * Convert.ToDouble(UnitPrice)                            
                        });

                        TotalAmount = TotalAmount + (Convert.ToDouble(Quantity) * Convert.ToDouble(UnitPrice));
                       
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new Command<ModelReturnEntryList>(async (item) =>
                {

                    ModelNumber = item.ModelNo;
                    Quantity = item.Qty;
                    UnitPrice = item.Price;
                    TotalAmount = TotalAmount - (Convert.ToDouble(item.Qty) * Convert.ToDouble(item.Price));
                    ModelReturnEntryLists.Remove(item);
                });
            }
        }

        public ObservableCollection<ModelReturnEntryList> ModelReturnEntryLists { get; set; } =
          new ObservableCollection<ModelReturnEntryList>();

        public ObservableCollection<UpdatedModelReturnEntryList> UpdatedModelReturnEntryLists { get; set; } =
         new ObservableCollection<UpdatedModelReturnEntryList>();

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

        private double _TotalAmount;
        public double TotalAmount

        {
            get { return _TotalAmount; }
            set
            {
                _TotalAmount = value;
                OnPropertyChanged("TotalAmount");
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

        private string _UnitPrice;
        public string UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                _UnitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }
        
    }
}


public class ModelReturnEntryList
{
    public string ModelNo { get; set; }
    public string Qty { get; set; }
    public string Price { get; set; }
    public double TotalAmount { get; set; }    
}

public class UpdatedModelReturnEntryList
{
    public string ModelNo { get; set; }
    public string Qty { get; set; }
    public string Price { get; set; }
    public double TotalAmount { get; set; }    
}