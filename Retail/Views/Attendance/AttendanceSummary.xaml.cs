using System;
using System.Collections.Generic;
using Retail.ViewModels.Attendance;
using Retail.ViewModels.Dashboard;
using Xamarin.Forms;

namespace Retail.Views.Attendance
{
    public partial class AttendanceSummary : ContentPage
    {
        AttendanceSummaryViewModel viewModel { get; set; }
        public AttendanceSummary()
        {
            InitializeComponent();
            BindingContext =viewModel= new AttendanceSummaryViewModel(Navigation);
        }

        void SearchStore_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
            var SearchButton = sender as SearchBar;
            if (!string.IsNullOrEmpty(SearchButton.Text))
            {
                viewModel.SearchAttendanceByStore(SearchButton.Text.Trim());
            }
        }

        void SearchStore_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string StoreName = string.Empty;
            if (!string.IsNullOrEmpty(e.NewTextValue))
                StoreName = e.NewTextValue.Trim();

            viewModel.SearchAttendanceByStore(StoreName.Trim());

        }
    }
}
