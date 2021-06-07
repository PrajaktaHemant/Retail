using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Retail.Views.MyVisits;
using Xamarin.Forms;

namespace Retail.ViewModels.MyVisits
{
    public class VisitTasksViewModel : BaseViewModel
    {
        

        public VisitTasksViewModel(INavigation navigation,string StoreName_, string StoreAddress_,string Distance_) : base(navigation)
        {
            StoreName = StoreName_; StoreAddress = StoreAddress_;Distance = Distance_;

            VisitTaskData.Add(new VisitTaskData { TaskName= "1. New product questionnaire" });
            VisitTaskData.Add(new VisitTaskData { TaskName = "2. Store visit" });
            VisitTaskData.Add(new VisitTaskData { TaskName = "3. Get information about..." });

            
        }

        public Command TaskItemCommand
        {
            get
            {
                return new Command<VisitTaskData>((item) =>
                {
                    Navigation.PushAsync(new TaskSummaryView(item.TaskName));
                });
            }
        }
        public ObservableCollection<VisitTaskData> VisitTaskData { get; set; } =
            new ObservableCollection<VisitTaskData>();

        private string _StoreName;
        public string StoreName

        {
            get { return _StoreName; }
            set
            {
                _StoreName = value;
                OnPropertyChanged("StoreName");
            }
        }
        private string _StoreAddress;
        public string StoreAddress

        {
            get { return _StoreAddress; }
            set
            {
                _StoreAddress = value;
                OnPropertyChanged("StoreAddress");
            }
        }
        private string _Distance;
        public string Distance

        {
            get { return _Distance; }
            set
            {
                _Distance = value;
                OnPropertyChanged("Distance");
            }
        }
    }
}

public class VisitTaskData
{
    public string TaskName { get; set; }    
}