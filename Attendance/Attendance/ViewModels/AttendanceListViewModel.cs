using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Attendance.ViewModels
{
    public class AttendanceListViewModel : ObservableObject
    {
        Services.IAttendanceService service;

        public ObservableCollection<Models.Attendance> Attendances { get; } = new ObservableCollection<Models.Attendance>();
        public string ButtonText => $"{(service.IsScanning ? "Stop" : "Start")} scanning for devices";
        public ICommand ToggleScanningForDevicesCommand { get; private set; }
        public ICommand ExportAttendancesCommand { get; private set; }
        public ICommand ShowAttendanceCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public AttendanceListViewModel(Services.IAttendanceService service)
        {
            this.service = service;
            this.service.DeviceDiscovered += OnDeviceDiscovered;
            this.ToggleScanningForDevicesCommand =
                new Command(async () => await OnToggleScanningForDevicesAsync());
            this.ExportAttendancesCommand = new Command(OnExportAttendances);
            this.ShowAttendanceCommand = new Command<Models.Attendance>(async (attendance) => await OnShowAttendance(attendance));
            this.ExitCommand = new Command(OnExit);
        }

        void OnExit(object obj)
        {
            Application.Current.Quit();
        }

        async Task OnShowAttendance(Models.Attendance attendance)
        {
            IDictionary<string, object> query = new Dictionary<string, object>();
            query["attendance"] = attendance;
            query["attendances"] = Attendances;
            await Shell.Current.GoToAsync("//attendance", query);
        }

        async Task OnToggleScanningForDevicesAsync()
        {
            OnPropertyChanged(nameof(ButtonText));
            await service.ToggleScanningForDevicesAsync();
        }

        void OnExportAttendances()
        {
            var fileName = $"attendances-{DateTime.Now.ToString("MM-dd-yyyy")}.txt";
            File.WriteAllLines(Path.Combine(FileSystem.CacheDirectory, fileName),
                Attendances.Select(attendance => $"{attendance.Attendee}({attendance.Device})").ToList());
        }

        void OnDeviceDiscovered(string deviceName)
        {
            var attendee = new Models.Attendance
            { 
                Attendee = "Unknown",
                Device = deviceName
            };
            Attendances.Add(attendee);
        }
    }
}
