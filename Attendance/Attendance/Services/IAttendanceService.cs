namespace Attendance.Services
{
    public delegate void DeviceDiscoveredEventHandler(string deviceName);
    public interface IAttendanceService
    {
        event DeviceDiscoveredEventHandler DeviceDiscovered;
        Task ToggleScanningForDevicesAsync();
        bool IsScanning { get; }
    }
}
