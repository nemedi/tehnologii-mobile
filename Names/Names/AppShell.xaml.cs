namespace Names;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		GoToAsync("//SearchName");
	}
}
