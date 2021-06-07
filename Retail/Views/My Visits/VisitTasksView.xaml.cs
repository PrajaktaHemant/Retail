using System;
using System.Collections.Generic;
using Retail.ViewModels.MyVisits;
using Xamarin.Forms;

namespace Retail.Views.MyVisits
{
    public partial class VisitTasksView : ContentPage
    {
        public VisitTasksView(string StoreName,string StoreAddress,string Distance)
        {
            InitializeComponent();
            BindingContext = new VisitTasksViewModel(Navigation, StoreName, StoreAddress, Distance);

        }
    }
}
