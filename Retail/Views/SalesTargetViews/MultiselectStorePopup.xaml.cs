using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Retail.Views.SalesTargetViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiselectStorePopup : PopupPage
    {
        List<StoresList> StoresLists = new List<StoresList>();
        List<CityList> CityLists = new List<CityList>();
        int _Flag; 
        public MultiselectStorePopup(int flag)
        {
            InitializeComponent();
            _Flag = flag;
            if (flag == 1)
            {
                StoresLists.Add(new StoresList() { Text = "Panasonic Store, Sharjah" });
                StoresLists.Add(new StoresList() { Text = "Panasonic Store, Dubai" });
                StoresLists.Add(new StoresList() { Text = "Panasonic Store, Ajman" });
                StoresLists.Add(new StoresList() { Text = "Panasonic Store, LULU" });

                listView.ItemsSource = StoresLists;
            }
            else if(flag==2)
            {
                CityLists.Add(new CityList() { Text = "Sharjah" });
                CityLists.Add(new CityList() { Text = "Dubai" });
                CityLists.Add(new CityList() { Text = "Ajman" });
                CityLists.Add(new CityList() { Text = "AbuDhabi" });

                listView.ItemsSource = CityLists;
            }
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopPopupAsync();
            if (_Flag == 1)
            {
                var result = StoresLists.Where(w => w.IsChecked == true).ToList();

                string s = "";

                int index = 0;
                foreach (var model in result)
                {
                    s = s + model.Text;
                    if (index < result.Count - 1)
                    {
                        s = s + ",";
                    }
                    index++;
                }

                MessagingCenter.Send<object, string>(this, "SelectedStoreLists", s);
            }
            else if (_Flag == 2)
            {
                var result = CityLists.Where(w => w.IsChecked == true).ToList();

                string s = "";

                int index = 0;
                foreach (var model in result)
                {
                    s = s + model.Text;
                    if (index < result.Count - 1)
                    {
                        s = s + ",";
                    }
                    index++;
                }

                MessagingCenter.Send<object, string>(this, "SelectedCityLists", s);
            }


        }
    }
}


public class StoresList : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    // This method is called by the Set accessor of each property.  
    // The CallerMemberName attribute that is applied to the optional propertyName  
    // parameter causes the property name of the caller to be substituted as an argument.  
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public StoresList()
    {
        IsChecked = false;
    }

    public string Text { get; set; }

    private bool isChecked;
    public bool IsChecked
    {
        get
        {
            return isChecked;
        }
        set
        {
            isChecked = value;
            NotifyPropertyChanged();
        }
    }
}

public class CityList : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    // This method is called by the Set accessor of each property.  
    // The CallerMemberName attribute that is applied to the optional propertyName  
    // parameter causes the property name of the caller to be substituted as an argument.  
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public CityList()
    {
        IsChecked = false;
    }

    public string Text { get; set; }

    private bool isChecked;
    public bool IsChecked
    {
        get
        {
            return isChecked;
        }
        set
        {
            isChecked = value;
            NotifyPropertyChanged();
        }
    }
}