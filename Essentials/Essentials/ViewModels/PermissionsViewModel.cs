namespace Essentials.ViewModels
{
	public class PermissionsViewModel : BaseViewModel
	{
		public List<Models.PermissionItem> PermissionItems =>
			new List<Models.PermissionItem>
			{
				new Models.PermissionItem("Battery", new Permissions.Battery()),
				new Models.PermissionItem("Calendar (Read)", new Permissions.CalendarRead()),
				new Models.PermissionItem("Calendar (Write)", new Permissions.CalendarWrite()),
				new Models.PermissionItem("Camera", new Permissions.Camera()),
				new Models.PermissionItem("Contacts (Read)", new Permissions.ContactsRead()),
				new Models.PermissionItem("Contacts (Write)", new Permissions.ContactsWrite()),
				new Models.PermissionItem("Flashlight", new Permissions.Flashlight()),
				new Models.PermissionItem("Launch Apps", new Permissions.LaunchApp()),
				new Models.PermissionItem("Location (Always)", new Permissions.LocationAlways()),
				new Models.PermissionItem("Location (Only When In Use)", new Permissions.LocationWhenInUse()),
				new Models.PermissionItem("Maps", new Permissions.Maps()),
				new Models.PermissionItem("Media Library", new Permissions.Media()),
				new Models.PermissionItem("Microphone", new Permissions.Microphone()),
				new Models.PermissionItem("Network State", new Permissions.NetworkState()),
				new Models.PermissionItem("Phone", new Permissions.Phone()),
				new Models.PermissionItem("Photos", new Permissions.Photos()),
				new Models.PermissionItem("Photos AddOnly", new Permissions.PhotosAddOnly()),
				new Models.PermissionItem("Reminders", new Permissions.Reminders()),
				new Models.PermissionItem("Sensors", new Permissions.Sensors()),
				new Models.PermissionItem("SMS", new Permissions.Sms()),
				new Models.PermissionItem("Speech", new Permissions.Speech()),
				new Models.PermissionItem("Storage (Read)", new Permissions.StorageRead()),
				new Models.PermissionItem("Storage (Write)", new Permissions.StorageWrite()),
				new Models.PermissionItem("Vibrate", new Permissions.Vibrate())
			};
	}
}
