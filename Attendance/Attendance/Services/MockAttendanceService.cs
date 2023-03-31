using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Services
{
    class MockAttendanceService : IAttendanceService
    {
        public event DeviceDiscoveredEventHandler DeviceDiscovered;
        public bool IsScanning { get; private set; } = false;

        public Task ToggleScanningForDevicesAsync()
        {
            if (!IsScanning)
            {
                for (int i = 0; i < 10; i++)
                {
                    DeviceDiscovered?.Invoke(Guid.NewGuid().ToString());
                }                  
            }
            IsScanning = !IsScanning;
            return Task.CompletedTask;
        }
    }
}
