using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Retail.Views.DemoControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : PopupPage
    {
        List<Model> list = new List<Model>();
        public Page2()
        {
            InitializeComponent();

            this.BackgroundColor = Color.White;


            list.Add(new Model() { Text = "A" });
            list.Add(new Model() { Text = "B" });
            list.Add(new Model() { Text = "C" });
            list.Add(new Model() { Text = "D" });

            listView.ItemsSource = list;
        }

        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();

            var result = list.Where(w => w.IsChecked == true).ToList();

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

            MessagingCenter.Send<object, string>(this, "Hi", s);
        }
    }
}


public class Model : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    // This method is called by the Set accessor of each property.  
    // The CallerMemberName attribute that is applied to the optional propertyName  
    // parameter causes the property name of the caller to be substituted as an argument.  
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Model()
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