namespace Attendance.Pages;

public partial class AttendanceListPage : ContentPage
{

	public AttendanceListPage(ViewModels.AttendanceListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        (BindingContext as ViewModels.AttendanceListViewModel)
			.ShowAttendanceCommand.Execute(e.SelectedItem as Models.Attendance);
    }
}

