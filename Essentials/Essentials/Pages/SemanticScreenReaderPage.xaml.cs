using System;
using Microsoft.Maui.Accessibility;

namespace Essentials.Pages
{
	public partial class SemanticScreenReaderPage : BasePage
	{
		public SemanticScreenReaderPage()
		{
			InitializeComponent();
		}

		void Announce_Clicked(object sender, EventArgs e)
		{
			SemanticScreenReader.Announce("This is the announcement text");
		}
	}
}
