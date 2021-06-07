using System;
using System.Collections.ObjectModel;
using Retail.DependencyServices;
using Xamarin.Forms;
using Retail.Hepler;

namespace Retail.ViewModels.ProductCatalogue
{
    public class BrochureViewModel : BaseViewModel
    {
        
        public BrochureViewModel(INavigation navigation) : base(navigation)
        {
            for (int i = 1; i < 10; i++)
            {
                BrochureData.Add(new BrochureList
                {
                    ProductCategory="Washing Machine",
                    ImageURL = $"https://picsum.photos/200?random={i}",CatalogueName="Catalogue 1", UploadDate="30/05/2021"
                });
            }
        }

        public ObservableCollection<BrochureList> BrochureData { get; set; } = new ObservableCollection<BrochureList>();

        
    }
}

public class BrochureList
{
    public string ProductCategory { get; set; }
    public string ImageURL { get; set; }
    public string CatalogueName { get; set; }
    public string UploadDate { get; set; }

}