using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyPopVinyls
{
	public class AddPopPage : ContentPage
	{
        private Entry _nameEntry;
        private Entry _franchiseEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

		public AddPopPage ()
		{
            this.Title = "Add Pop Vinyl!";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Pop Vinyl! Character";
            stackLayout.Children.Add(_nameEntry);

            _franchiseEntry = new Entry();
            _franchiseEntry.Keyboard = Keyboard.Text;
            _franchiseEntry.Placeholder = "Pop Vinyl! Franchise/Movie/Show";
            stackLayout.Children.Add(_franchiseEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add Pop Vinyl!";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;

        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<PopVinyl>();

            var maxPk = db.Table<PopVinyl>().OrderByDescending(c => c.Id).FirstOrDefault();

            PopVinyl pop = new PopVinyl()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = _nameEntry.Text,
                Franchise = _franchiseEntry.Text

            };
            db.Insert(pop);
            await DisplayAlert(null, pop.Name + "Pop Added!", "OK");
            await Navigation.PopAsync();
        }
    }
}