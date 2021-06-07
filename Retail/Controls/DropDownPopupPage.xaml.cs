using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Retail.Infrastructure.ServiceLayer;
using Retail.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Retail.Controls
{
    public partial class DropDownPopupPage : PopupPage
    {
        public DropDownPopupPage()
        {
            InitializeComponent();
            cvList.BindingContext = this;
            this.BindingContext = this;

        }
        public static BindableProperty TitleProperty =
          BindableProperty.Create(nameof(Title), typeof(string), typeof(DropDownPopupPage), null, BindingMode.TwoWay);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, FirstCharToUpper(value));
        }
        public void SetSearchKey(string key)
        {
            sbKey.Text = key;
        }
        public string SearchKey { get; set; }
        public static readonly BindableProperty PickerItemsSourceProperty = BindableProperty.Create("PickerItemsSource", typeof(IList), typeof(DropDownPopupPage), null, BindingMode.TwoWay, propertyChanged: ItemsSourceChanged);

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DropDownPopupPage)bindable;
            // control.dropdown.ItemsSource = (IList)newValue;
        }
        /// <summary>
        /// Accessors
        /// </summary>
        public List<DropDownModel> MasterData { get; set; }
        public IList PickerItemsSource
        {
            get { return (IList)GetValue(PickerItemsSourceProperty); }
            set
            {
                SetValue(PickerItemsSourceProperty, value);
            }
        }
        public static readonly BindableProperty SelectedItemProperty =
          BindableProperty.Create(nameof(SelectedItem),
              typeof(DropDownModel),
              typeof(DropDownPopupPage),
              null,
              BindingMode.TwoWay, propertyChanged: OnSelectedItemPropertyChanged);

        private static void OnSelectedItemPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var control = (DropDownPopupPage)bindable;
            control.SelectedItem = newValue as DropDownModel;

        }
        public DropDownModel SelectedItem
        {
            get
            {
                return this.GetValue(SelectedItemProperty) as DropDownModel;
            }
            set
            {

                this.SetValue(SelectedItemProperty, value);
            }
        }
        async void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {

            if (Title.Contains("Model"))
            {
                string sKey = "";
                if (!string.IsNullOrEmpty(e.NewTextValue))
                    sKey = e.NewTextValue.Trim();
                // SearchModelNumberByInitials
                if (sKey.Count() >= 2)
                    await GetModelNumber(e.NewTextValue);
            }
            else
            {

                PickerItemsSource = MasterData.Where(u => u.Title.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
            }
        }
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        public async Task GetModelNumber(string skey)
        {
            //MasterDataManagementSL dataManagementSL = new MasterDataManagementSL();

            ////List<ModelNumberSearchResponse> modelNumberSearchResponses = await dataManagementSL.SearchModelNumberByInitials(skey, 0);
            //List<DropDownModel> dropDownModels = new List<DropDownModel>();
            //if (modelNumberSearchResponses != null)
            //{
            //    foreach (var item in modelNumberSearchResponses)
            //    {
            //        dropDownModels.Add(new DropDownModel() { Title = item.ModelName, Id = item.ProductClassificationId, Desc = item.ModelDescreption });
            //    }
            //}
            //PickerItemsSource = dropDownModels;
        }
        public event EventHandler DropDownSelectedItem;

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            EventHandler handler = DropDownSelectedItem;
            if (handler != null)
            {
                SelectedItem = e.CurrentSelection[0] as DropDownModel;
                handler(this, e);
                handler.Invoke(this, e);
                PopupNavigation.PopAsync();
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}
