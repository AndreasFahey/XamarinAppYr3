using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPopVinyls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPopPage : ContentPage
	{
		public NewPopPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Pop Added!", "Click Event Handled", "Success!");
        }
    }
}