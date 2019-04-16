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
    public partial class MyCollectionPage : ContentPage
    {
        public MyCollectionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<PopVinyl>();

                var popvinyls = conn.Table<PopVinyl>().ToList();
                popListView.ItemsSource = popvinyls;
            }
        }
    }
}