﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyPopVinyls
{
    public class DeletePopsPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        PopVinyl _pop = new PopVinyl();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeletePopsPage()
        {
            this.Title = "Delete Pop From Collection";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<PopVinyl>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete Pop!";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _pop = (PopVinyl)e.SelectedItem;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<PopVinyl>().Delete(x => x.Id == _pop.Id);
            await Navigation.PopAsync();
        }
    }
}