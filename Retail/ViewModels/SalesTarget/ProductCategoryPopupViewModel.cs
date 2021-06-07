using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Retail.Views.InventoryStock;
using Retail.Views.SalesTargetViews;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Retail.ViewModels.SalesTarget
{
    public class ProductCategoryPopupViewModel : BaseViewModel
    {
        public ObservableCollection<ModelNoList> ModelNosList { get; set; } =
          new ObservableCollection<ModelNoList>();
        public ProductCategoryPopupViewModel(INavigation navigation, int flag): base(navigation)
        {
            Flag = flag;
            for (int i = 0; i < 10; i++)
            {
                ModelNosList.Add(new ModelNoList
                {
                    ModelNumber = "MX-123456A" + i
                });
            }

        }

        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ModelNosList.Add(new ModelNoList
                        {
                            ModelNumber = "MX-123456A"+i
                        });
                    }
                });
            }
        }

        
        public ICommand SelectModelNoCommand
        {
           
            get
            {
                return new Command<ModelNoList>(async (item) =>
                {
                    //if (Navigation.NavigationStack.Count == 0 || Navigation.NavigationStack.Last().GetType() != typeof(SalesDataEntry))
                    //{
                    if (Flag == 1)
                    {
                        
                        await Navigation.PushAsync(new SalesDataEntry(item.ModelNumber), true);
                        await PopupNavigation.PopAsync();
                    }
                    else if (Flag == 2)
                    {
                        await Navigation.PushAsync(new AddInventoryStock(item.ModelNumber), true);
                        await PopupNavigation.PopAsync();
                    }
                    //}

                });
            }
        }


        private int _Flag;
        public int Flag

        {
            get { return _Flag; }
            set
            {
                _Flag = value;
                OnPropertyChanged("Flag");
            }
        }
    } 
}


public class ProductCategory
{
    public string ProductCategoryName { get; set; }
}

public class ModelNoList
{
    public string ModelNumber { get; set; }
}