namespace Essentials.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		bool alreadyAppeared;
		Models.SampleItem[] samples;
		IEnumerable<Models.SampleItem> filteredItems;
		string filterText;

		public HomeViewModel()
		{
			alreadyAppeared = false;
			samples = new Models.SampleItem[]
			{
				new Models.SampleItem(
					"📏",
					"Accelerometer",
					typeof(Pages.AccelerometerPage),
					"Retrieve acceleration data of the device in 3D space.",
					new[] { "accelerometer", "sensors", "hardware", "device" }),
				new Models.SampleItem(
					"📏",
					"All Sensors",
					typeof(Pages.AllSensorsPage),
					"Have a look at the accelerometer, barometer, compass, gyroscope, magnetometer, and orientation sensors.",
					new[] { "accelerometer", "barometer", "compass", "gyroscope", "magnetometer", "orientation", "sensors", "hardware", "device" }),
				new Models.SampleItem(
					"📦",
					"App Info",
					typeof(Pages.AppInfoPage),
					"Find out about the app with ease.",
					new[] { "app", "info" }),
				new Models.SampleItem(
					"📏",
					"Barometer",
					typeof(Pages.BarometerPage),
					"Easily detect pressure level, via the device barometer.",
					new[] { "barometer", "hardware", "device", "sensor" }),
				new Models.SampleItem(
					"🔋",
					"Battery",
					typeof(Pages.BatteryPage),
					"Easily detect battery level, source, and state.",
					new[] { "battery", "hardware", "device" }),
				new Models.SampleItem(
					"🌐",
					"Browser",
					typeof(Pages.BrowserPage),
					"Quickly and easily open a browser to a specific website.",
					new[] { "browser", "web", "internet" }),
				new Models.SampleItem(
					"📋",
					"Clipboard",
					typeof(Pages.ClipboardPage),
					"Quickly and easily use the clipboard.",
					new[] { "clipboard", "copy", "paste" }),
				new Models.SampleItem(
					"🎨",
					"Color Converters",
					typeof(Pages.ColorConvertersPage),
					"Convert and adjust colors.",
					new[] { "color", "drawing", "style" }),
				new Models.SampleItem(
					"🧭",
					"Compass",
					typeof(Pages.CompassPage),
					"Monitor compass for changes.",
					new[] { "compass", "sensors", "hardware", "device" }),
				new Models.SampleItem(
					"📶",
					"Connectivity",
					typeof(Pages.ConnectivityPage),
					"Check connectivity state and detect changes.",
					new[] { "connectivity", "internet", "wifi" }),
				new Models.SampleItem(
					"👶",
					"Contacts",
					typeof(Pages.ContactsPage),
					"Get and add contacts in your device.",
					new[] { "contacts", "people", "device" }),
				new Models.SampleItem(
					"📱",
					"Device Info",
					typeof(Pages.DeviceInfoPage),
					"Find out about the device with ease.",
					new[] { "hardware", "device", "info", "screen", "display", "orientation", "rotation" }),
				new Models.SampleItem(
					"📧",
					"Email",
					typeof(Pages.EmailPage),
					"Easily send email messages.",
					new[] { "email", "share", "communication", "message" }),
				new Models.SampleItem(
					"📁",
					"File Picker",
					typeof(Pages.FilePickerPage),
					"Easily pick files from storage.",
					new[] { "files", "picking", "filesystem", "storage" }),
				new Models.SampleItem(
					"📁",
					"File System",
					typeof(Pages.FileSystemPage),
					"Easily save files to app data.",
					new[] { "files", "directory", "filesystem", "storage" }),
				new Models.SampleItem(
					"🔦",
					"Flashlight",
					typeof(Pages.FlashlightPage),
					"A simple way to turn the flashlight on/off.",
					new[] { "flashlight", "torch", "hardware", "flash", "device" }),
				new Models.SampleItem(
					"📍",
					"Geocoding",
					typeof(Pages.GeocodingPage),
					"Easily geocode and reverse geocoding.",
					new[] { "geocoding", "geolocation", "position", "address", "mapping" }),
				//new Models.SampleItem(
				//	"📍",
				//	"Geolocation",
				//	typeof(Pages.GeolocationPage),
				//	"Quickly get the current location.",
				//	new[] { "geolocation", "position", "address", "mapping" }),
				new Models.SampleItem(
					"💤",
					"Keep Screen On",
					typeof(Pages.KeepScreenOnPage),
					"Keep the device screen awake.",
					new[] { "screen", "awake", "sleep" }),
				new Models.SampleItem(
					"📏",
					"Launcher",
					typeof(Pages.LauncherPage),
					"Launch other apps via Uri",
					new[] { "launcher", "app", "run" }),
				new Models.SampleItem(
					"📏",
					"Gyroscope",
					typeof(Pages.GyroscopePage),
					"Retrieve rotation around the device's three primary axes.",
					new[] { "gyroscope", "sensors", "hardware", "device" }),
				new Models.SampleItem(
					"📏",
					"Magnetometer",
					typeof(Pages.MagnetometerPage),
					"Detect device's orientation relative to Earth's magnetic field.",
					new[] { "compass", "magnetometer", "sensors", "hardware", "device" }),
				new Models.SampleItem(
					"🗺",
					"Launch Maps",
					typeof(Pages.MapsPage),
					"Easily launch maps with coordinates.",
					new[] { "geocoding", "geolocation", "position", "address", "mapping", "maps", "route", "navigation" }),
				new Models.SampleItem(
					"📏",
					"Orientation Sensor",
					typeof(Pages.OrientationSensorPage),
					"Retrieve orientation of the device in 3D space.",
					new[] { "orientation", "sensors", "hardware", "device" }),
				new Models.SampleItem(
					"📷",
					"Media Picker",
					typeof(Pages.MediaPickerPage),
					"Pick or capture a photo or video.",
					new[] { "media", "picker", "video", "picture", "photo", "image", "movie" }),
				new Models.SampleItem(
					"🔒",
					"Permissions",
					typeof(Pages.PermissionsPage),
					"Request various permissions.",
					new[] { "permissions" }),
				new Models.SampleItem(
					"📞",
					"Phone Dialer",
					typeof(Pages.PhoneDialerPage),
					"Easily open the phone dialer.",
					new[] { "phone", "dialer", "communication", "call" }),
				new Models.SampleItem(
					"⚙️",
					"Preferences",
					typeof(Pages.PreferencesPage),
					"Quickly and easily add persistent preferences.",
					new[] { "settings", "preferences", "prefs", "storage" }),
				new Models.SampleItem(
					"📷",
					"Screenshot",
					typeof(Pages.ScreenshotPage),
					"Quickly and easily take screenshots of your app.",
					new[] { "screenshot", "picture", "media", "display" }),
				new Models.SampleItem(
					"🔒",
					"Secure Storage",
					typeof(Pages.SecureStoragePage),
					"Securely store data.",
					new[] { "settings", "preferences", "prefs", "security", "storage" }),
				new Models.SampleItem(
					"🐊",
					"Semantic Screen Reader",
					typeof(Pages.SemanticScreenReaderPage),
					"Read out the semanic contents of a screen.",
					new[] { "accessibility", "a11y", "screen reader", "semantic" }),
				new Models.SampleItem(
					"📲",
					"Share",
					typeof(Pages.SharePage),
					"Send text, website uris and files to other apps.",
					new[] { "data", "transfer", "share", "communication" }),
				new Models.SampleItem(
					"💬",
					"SMS",
					typeof(Pages.SMSPage),
					"Easily send SMS messages.",
					new[] { "sms", "message", "text", "communication", "share" }),
				new Models.SampleItem(
					"🔊",
					"Text To Speech",
					typeof(Pages.TextToSpeechPage),
					"Vocalize text on the device.",
					new[] { "text", "message", "speech", "communication" }),
				new Models.SampleItem(
					"🌡",
					"Unit Converters",
					typeof(Pages.UnitConvertersPage),
					"Easily converter different units.",
					new[] { "units", "converters", "calculations" }),
				new Models.SampleItem(
					"📳",
					"Vibration",
					typeof(Pages.VibrationPage),
					"Quickly and easily make the device vibrate.",
					new[] { "vibration", "vibrate", "hardware", "device" }),
				new Models.SampleItem(
					"📳",
					"Haptic Feedback",
					typeof(Pages.HapticFeedbackPage),
					"Quickly and easily make the device provide haptic feedback",
					new[] { "haptic", "feedback", "hardware", "device" }),
				new Models.SampleItem(
					"🔓",
					"Web Authenticator",
					typeof(Pages.WebAuthenticatorPage),
					"Quickly and easily authenticate and wait for a callback.",
					new[] { "auth", "authenticate", "authenticator", "web", "webauth" }),
			};
			filteredItems = samples;
			filterText = string.Empty;
		}

		public IEnumerable<Models.SampleItem> FilteredItems
		{
			get => filteredItems;
			private set => SetProperty(ref filteredItems, value);
		}

		public string FilterText
		{
			get => filterText;
			set
			{
				SetProperty(ref filterText, value);
				FilteredItems = Filter(samples, value);
			}
		}

		public override void OnAppearing()
		{
			base.OnAppearing();

			if (!alreadyAppeared)
			{
				alreadyAppeared = true;

				if (VersionTracking.IsFirstLaunchEver)
				{
					DisplayAlertAsync("Welcome to the Samples! This is the first time you are launching the app!");
				}
				else if (VersionTracking.IsFirstLaunchForCurrentVersion)
				{
					var count = VersionTracking.VersionHistory.Count();
					DisplayAlertAsync($"Welcome to the NEW Samples! You have tried {count} versions.");
				}
			}
		}

		static IEnumerable<Models.SampleItem> Filter(IEnumerable<Models.SampleItem> samples, string filterText)
		{
			if (!string.IsNullOrWhiteSpace(filterText))
			{
				samples = samples.Where(s =>
				{
					var tags = s.Tags.Union(new[] { s.Name });
					return tags.Any(t => t.Contains(filterText, StringComparison.OrdinalIgnoreCase));
				});
			}

			return samples.OrderBy(s => s.Name);
		}
	}
}
