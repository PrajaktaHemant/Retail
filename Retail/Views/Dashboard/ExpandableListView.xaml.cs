using System;
using System.Collections.Generic;
using Retail.Controls;
using Retail.ViewModels.Dashboard;
using Xamarin.Forms;

namespace Retail.Views.Dashboard
{
    public partial class ExpandableListView : ContentPage
    {
        public ExpandableListView()
        {
            InitializeComponent();
            MainOne.DataSource = GetSampleData();
            MainOne.DataBind();
            SecOne.DataSource = GetSampleData();
            SecOne.DataBind();
        }

        void OnListItemClicked(object o, ItemTappedEventArgs e)
        {
            //var vListItem = e.Item as SimpleObject;
            //var vMessage = "You Clicked on " + vListItem.TextValue + " With Value " + vListItem.DataValue;
            //DisplayAlert("Message", vMessage, "Ok");

           

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
                    TextValue = "ObjectNo-" + iCount.ToString(),
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

           

            #region StackLayout
            var vViewLayout = new StackLayout()
            {
                Children = {
                    new Label { Text = "Static Content:" },
                    new Label { Text = "Name : Sample123" },
                    new Label { Text = "Roles : Father,Trainer,Consultant,Architect" }
                }
            };
            #endregion

            var vFirstAccord = new AccordionSource()
            {
                HeaderText = "First",
                HeaderTextColor = Color.Black,
                HeaderBackGroundColor = Color.White,
                ContentItems = vListViewOne
            };
            vResult.Add(vFirstAccord);
            var vSecond = new AccordionSource()
            {
                HeaderText = "Second ",
                HeaderTextColor = Color.Black,
                HeaderBackGroundColor = Color.White,
                ContentItems = vViewLayout
            };
            vResult.Add(vSecond);
            var vThird = new AccordionSource()
            {
                HeaderText = "Third",
                HeaderTextColor = Color.Black,
                HeaderBackGroundColor = Color.White,
                ContentItems = vListViewOne
            };
            vResult.Add(vThird);

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

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            MainOne.DataSource = GetSampleData();
            MainOne.DataBind();
            //SecOne.DataSource = GetSampleData();
            //SecOne.DataBind();
        }

      
        //private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var product = e.Item as Product;
        //    var vm = BindingContext as MainViewModel;
        //    vm?.ShowOrHidePoducts(product);
        //}
    }
}
