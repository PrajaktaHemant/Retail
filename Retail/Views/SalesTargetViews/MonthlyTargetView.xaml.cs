using System;
using System.Collections.Generic;
using Retail.Controls;
using Retail.ViewModels.SalesTarget;
using Xamarin.Forms;

namespace Retail.Views.SalesTargetViews
{
    public partial class MonthlyTargetView : ContentPage
    {
        MonthlyTargetViewModel viewModel { get; set; }
        List<StoreList> StoresList { get; set; }

        public MonthlyTargetView()
        {
            InitializeComponent();
            BindingContext = viewModel= new MonthlyTargetViewModel(Navigation);

            StoresList = new List<StoreList>();
            StoresList.Add(new StoreList { StoreName = "Panasonic Store LULU" });
            StoresList.Add(new StoreList { StoreName = "Panasonic Store, Sharjah" });
            StoresList.Add(new StoreList { StoreName = "Panasonic Store, Dubai" });
            StoresList.Add(new StoreList { StoreName = "Panasonic Store, SAFARI" });

            StoreDropdown.ItemsSource = StoresList;
            StoreDropdown.SelectedItem = StoresList[0];

            MainOne.DataSource = GetSampleData();
            MainOne.DataBind();
        }
        void OnListItemClicked(object o, ItemTappedEventArgs e)
        {
            
        }

        public List<AccordionSource> GetSampleData()
        {

            var vResult = new List<AccordionSource>();

            #region First List View
            var vListOne = new List<SimpleObject>();
            for (var iCount = 0; iCount < 6; iCount++)
            {
                var vObject = new SimpleObject()
                {
                    TextValue = "Front Loading" + iCount.ToString(),
                    DataValue = iCount.ToString()
                };
                vListOne.Add(vObject);
            }

            var vListViewOne = new ListView()
            {
                ItemsSource = vListOne,
                ItemTemplate = new DataTemplate(typeof(ListDataViewCell))
            };
            vListViewOne.ItemTapped += OnListItemClicked;
            #endregion
             var first = new AccordionSource()
                {
                    HeaderText = "Washing Machine",
                    HeaderTextColor = Color.Black,
                    HeaderBackGroundColor = Color.White,
                    ContentItems = vListViewOne
                };
                vResult.Add(first);
            var second = new AccordionSource()
            {
                HeaderText = "TV",
                HeaderTextColor = Color.Black,
                HeaderBackGroundColor = Color.White,
                ContentItems = vListViewOne
            };
            vResult.Add(second);
            return vResult;
        }

        public class SampleStackLayout : ViewCell
        {
            public SampleStackLayout()
            {
                var result = new List<AccordionSource>();

                var sample = new StackLayout()
                {
                    Children = {
                    new Label { Text = "Static Content:" },}
                };
                var addrecord = new AccordionSource()
                {
                    HeaderText = "First",
                    HeaderTextColor = Color.Black,
                    HeaderBackGroundColor = Color.White,
                    ContentItems = sample
                };
                result.Add(addrecord);
            }
        }


        public class ListDataViewCell : ViewCell
        {
            public ListDataViewCell()
            {
                var label = new Label()
                {
                    Font = Font.SystemFontOfSize(NamedSize.Default),
                    TextColor = Color.Blue
                };
                label.SetBinding(Label.TextProperty, new Binding("TextValue"));
                label.SetBinding(Label.ClassIdProperty, new Binding("DataValue"));
                View = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Padding = new Thickness(12, 8),
                    Children = { label }
                };
            }
        }

        public class SimpleObject
        {
            public string TextValue
            { get; set; }
            public string DataValue
            { get; set; }
        }

        void TitledDateTimePicker_ItemTapped(System.Object sender, System.EventArgs e)
        {
            var datePicker = sender as DatePicker;
            datePicker.Format = "MM/yyyy";            
            viewModel.SelectedDate = datePicker.Date;
        }

        void StoreDropdown_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
        }
    }
}
