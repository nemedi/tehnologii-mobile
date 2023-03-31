using System.Collections.ObjectModel;

namespace Attendance.Pages;

public partial class AttendancePage : ContentPage, IQueryAttributable
{
	public AttendancePage(ViewModels.AttendanceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		(BindingContext as ViewModels.AttendanceViewModel).Attendance = query["attendance"] as Models.Attendance;
		(BindingContext as ViewModels.AttendanceViewModel).Attendances = query["attendance"] as ObservableCollection<Models.Attendance>;
    }
}