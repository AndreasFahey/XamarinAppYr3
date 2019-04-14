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
            PopVinyl popvinyl = new PopVinyl()
            {
                Brand = brandEntry.Text,
                Character = characterEntry.Text,
                Issue = int.Parse(issueEntry.Text)
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<PopVinyl>();
                var numberOfRows = conn.Insert(popvinyl);

                if(numberOfRows > 0)
                    DisplayAlert("Pop Added!", "Pop Vinyl Was Successfully added to Collection", "Success!");
                else
                    DisplayAlert("Oops!", "Pop Vinyl Was Not Added To Collection", "Check Entry and Try Again");
            }
            
            
        }
    }
}