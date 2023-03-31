using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Attendance.ViewModels
{
    public class AttendanceViewModel : ObservableObject
    {
        Models.Attendance attendance;
        public Models.Attendance Attendance
        {
            get => attendance;
            set
            {
                attendance = value;
                Attendee = attendance?.Attendee;
                Device = attendance?.Device;
            }
        }
        public ObservableCollection<Models.Attendance> Attendances { get; set; }
        public ICommand SaveAttendanceCommand { get; private set; }
        public ICommand RemoveAttendanceCommand { get; private set; }
        public string Attendee
        {
            get => attendance?.Attendee;
            set
            {
                attendance.Attendee = value;
                OnPropertyChanged();
            }
        }
        public string Device
        {
            get => attendance?.Device;
            set
            {
                attendance.Device = value;
                OnPropertyChanged();
            }
        }
        public AttendanceViewModel()
        {
            SaveAttendanceCommand = new Command(async () => await OnSaveAttendance());
            RemoveAttendanceCommand = new Command(async () => await OnRemoveAttendance());
        }

        async Task OnSaveAttendance()
        {
            await Shell.Current.GoToAsync("//attendances");
        }

        async Task OnRemoveAttendance()
        {
            Attendances?.Remove(attendance);
            await Shell.Current.GoToAsync("//attendances");
        }

    }
}
