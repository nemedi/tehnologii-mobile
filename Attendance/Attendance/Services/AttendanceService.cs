using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace Attendance.Services
{
    
    public class AttendanceService : IAttendanceService
    {
        IAdapter adapter;
        public event DeviceDiscoveredEventHandler DeviceDiscovered;

        public AttendanceService()
        {
            this.adapter = CrossBluetoothLE.Current.Adapter;
            adapter.DeviceDiscovered += (sender, arguments) => DeviceDiscovered?.Invoke(arguments.Device.Name);
        }
        public bool IsScanning => adapter.IsScanning;
        public async Task ToggleScanningForDevicesAsync()
        {
            if (adapter.IsScanning)
            {
                await adapter.StopScanningForDevicesAsync();
            }
            else
            {
                adapter.ScanTimeout = int.MaxValue;
                await adapter.StartScanningForDevicesAsync();
            }
        }

    }
}
