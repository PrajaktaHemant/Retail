using System;
using System.Collections.Generic;
using Retail.ViewModels.MyVisits;
using Xamarin.Forms;

namespace Retail.Views.MyVisits
{
    public partial class TaskSummaryView : ContentPage
    {
        public TaskSummaryView(string TaskName)
        {
            InitializeComponent();
            BindingContext = new TaskSummaryViewModel(Navigation, TaskName);
        }
    }
}
