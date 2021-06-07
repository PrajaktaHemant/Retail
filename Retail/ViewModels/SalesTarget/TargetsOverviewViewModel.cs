using System;
using System.Collections.ObjectModel;
using Retail.ViewModels.MonthYearPickerViewModel;
using Xamarin.Forms;

namespace Retail.ViewModels.SalesTarget
{
    public class TargetsOverviewViewModel : BaseViewModel
    {
        public TargetsOverviewViewModel(INavigation navigation):base(navigation)
        {
            
        }
        public Command ViewTargetsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    TargetOverviewLists.Add(new TargetOverviewData { PromoterName = "Promoter1", StoreName = "Panasonic Store 1", Taregt = "20,100", Achieved = "20,000", Balance = "100", Percentage = "10%" });
                    TargetOverviewLists.Add(new TargetOverviewData { PromoterName = "Promoter2", StoreName = "Panasonic Store 2", Taregt = "20,500", Achieved = "20,000", Balance = "500", Percentage = "15%" });
                    TargetOverviewLists.Add(new TargetOverviewData { PromoterName = "Promoter3", StoreName = "Panasonic Store 3", Taregt = "20,200", Achieved = "20,000", Balance = "200", Percentage = "20%" });
                    TargetOverviewLists.Add(new TargetOverviewData { PromoterName = "Promoter4", StoreName = "Panasonic Store 4", Taregt = "20,300", Achieved = "20,000", Balance = "300", Percentage = "30%" });

                });

            }
        }

        public ObservableCollection<TargetOverviewData> TargetOverviewLists { get; set; } =
          new ObservableCollection<TargetOverviewData>();
    }
}

public class TargetOverviewData
{
    public string PromoterName { get; set; }
    public string StoreName { get; set; }
    public string Taregt { get; set; }
    public string Achieved { get; set; }
    public string Balance { get; set; }
    public string Percentage { get; set; }

}
