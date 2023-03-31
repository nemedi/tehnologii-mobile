namespace Essentials.Pages
{
	public partial class HomePage : BasePage
	{
		public HomePage()
		{
			InitializeComponent();
		}

		async void OnSampleTapped(object sender, SelectionChangedEventArgs e)
		{
			var item = e.CurrentSelection?.FirstOrDefault() as Models.SampleItem;
			if (item == null)
				return;

			await Navigation.PushAsync((Page)Activator.CreateInstance(item.PageType));

			// deselect Item
			((CollectionView)sender).SelectedItem = null;
		}
	}
}
