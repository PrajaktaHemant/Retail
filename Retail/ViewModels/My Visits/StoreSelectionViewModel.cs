using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Retail.ViewModels.MyVisits
{
    public class StoreSelectionViewModel : BaseViewModel
    {
        public StoreSelectionViewModel(INavigation navigation):base(navigation)
        {
            for (int i = 1; i < 9; i++)
            {
                StoreSelections.Add(new StoreSelectionData
                {
                    StoreName = "Panasonic Store 1- lulu",
                    StoreAddress = "Near to Mall of the Emirates, Dubai",
                    Distance = "27 km"
                });
            }
        }

        public ObservableCollection<StoreSelectionData> StoreSelections { get; set; } =
           new ObservableCollection<StoreSelectionData>();
    }
}

public class StoreSelectionData
{
    public string StoreName { get; set; }
    public string StoreAddress { get; set; }
    public string Distance { get; set; }    
}