using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Retail.ViewModels.Attendance
{
    public class AttendanceSummaryViewModel : BaseViewModel
    {
        public AttendanceSummaryViewModel(INavigation navigation):base(navigation)
        {
            for (int i = 1; i < 5; i++)
            {
                _AttendanceSummary.Add(new _AttendanceSummary
                {
                    AttendanceDate = DateTime.Now.ToString("dd/MM/yyyy"),
                    PromoterName = "Promoter" + i,
                    StoreName = "Panasonic Store 1- lulu",
                    HistoryCheckInTime = "08:00 AM",
                    HistoryCheckOutTime = "04:30 PM"
                }); 
            }
        }

        public void SearchAttendanceByStore(string Store)
        {
            if (!string.IsNullOrEmpty(Store))
            {
                var SearchTargetByProduct = _SearchAttendanceSummary.Where(u => u.StoreName.Contains(Store));
                _AttendanceSummary = new ObservableCollection<_AttendanceSummary>(_SearchAttendanceSummary);
            }
            else
                _AttendanceSummary = _SearchAttendanceSummary;
        }

        public ObservableCollection<_AttendanceSummary> _AttendanceSummary { get; set; } =
           new ObservableCollection<_AttendanceSummary>();

        public ObservableCollection<_AttendanceSummary> _SearchAttendanceSummary { get; set; } =
           new ObservableCollection<_AttendanceSummary>();
    }
}

public class _AttendanceSummary
{
    public string AttendanceDate { get; set; }
    public string PromoterName { get; set; }
    public string StoreName { get; set; }
    public string HistoryCheckInTime { get; set; }
    public string HistoryCheckOutTime { get; set; }
}