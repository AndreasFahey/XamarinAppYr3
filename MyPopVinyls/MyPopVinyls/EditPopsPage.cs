using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyPopVinyls
{
    public class EditPopsPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _franchiseEntry;
        private Button _button;

        PopVinyl _pop = new PopVinyl();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditPopsPage()
        {
            this.Title = "Edit Collection";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<PopVinyl>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "POP ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "POP VINLY! CHARACTER";
            stackLayout.Children.Add(_nameEntry);

            _franchiseEntry = new Entry();
            _franchiseEntry.Keyboard = Keyboard.Text;
            _franchiseEntry.Placeholder = "POP VINYL! FRANCHISE";
            stackLayout.Children.Add(_franchiseEntry);

            _button = new Button();
            _button.Text = "Update Pop Deatils";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            PopVinyl pop = new PopVinyl()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Franchise = _franchiseEntry.Text
            };
            db.Update(pop);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _pop = (PopVinyl)e.SelectedItem;
            _idEntry.Text = _pop.Id.ToString();
            _nameEntry.Text = _pop.Name;
            _franchiseEntry.Text = _pop.Franchise;


        }
    }
}