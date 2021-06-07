using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Retail.Views.SalesTargetViews;
using Xamarin.Forms;

namespace Retail.ViewModels.SalesTarget
{
    public class MonthlyTargetViewModel :  BaseViewModel
    {
        public MonthlyTargetViewModel(INavigation navigation ): base(navigation)
        {
            for(int i = 1; i < 9; i++)
            {
                SalesTargetData.Add(new SalesData
                {
                    Target = "100,000",
                    Achieved = "25,000",
                    Balance = "-5000",
                    MachineName = "Washing Machine"

                });
            }
        }

        public void BindingMonthlySalesData()
        {
            
            //SalesTargetManagementSL salesTargetManagement = new SalesTargetManagementSL();
        }

        public Command TargetItemCommand
        {
            get
            {
                return new Command<SalesData>((item) =>
                {
                    Navigation.PushAsync(new TargetsByProductCategoryView(item.MachineName));
                });
            }
        }

        public ObservableCollection<SalesData> SalesTargetData { get; set; } =
            new ObservableCollection<SalesData>();


        private string _ModelName;
        public string ModelName

        {
            get { return _ModelName; }
            set
            {
                _ModelName = value;
                OnPropertyChanged("ModelName");
            }
        }

        private string _Target;
        public string Target

        {
            get { return _Target; }
            set
            {
                _Target = value;
                OnPropertyChanged("Target");
            }
        }

        private string _Achived;
        public string Achived

        {
            get { return _Achived; }
            set
            {
                _Achived = value;
                OnPropertyChanged("Achived");
            }
        }

        private string _Balance;
        public string Balance

        {
            get { return _Balance; }
            set
            {
                _Balance = value;
                OnPropertyChanged("Balance");
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
    }
}

public class SalesData
{
    public string Target { get; set; }
    public string Achieved { get; set; }
    public string Balance { get; set; }
    public string MachineName { get; set; }
}