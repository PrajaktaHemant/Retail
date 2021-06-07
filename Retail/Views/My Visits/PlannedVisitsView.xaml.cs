using System;
using System.Collections.Generic;
using Retail.ViewModels.MyVisits;
using Xamarin.Forms;

namespace Retail.Views.MyVisits
{
    public partial class PlannedVisitsView : ContentPage
    {
        public PlannedVisitsView()
        {
            InitializeComponent();
            BindingContext = new PlannedVisitsViewModel(Navigation);
        }
    }
}
