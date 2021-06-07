using System;
using System.Collections.Generic;
using Retail.DependencyServices;
using Retail.ViewModels.MonthYearPickerViewModel;
using Retail.ViewModels.SalesTarget;
using Xamarin.Forms;

namespace Retail.Views.SalesTargetViews
{
    public partial class SalesDataReturnEntry : ContentPage
    {
        SalesDataReturnEntryViewModel viewModel { get; set; }
        public SalesDataReturnEntry()
        {            
            InitializeComponent();            
            BindingContext = viewModel = new SalesDataReturnEntryViewModel(Navigation);
        }
    }
}
