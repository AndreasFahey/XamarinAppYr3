using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyPopVinyls
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
            this.Title = "My Pop! Vinyl";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Pop Vinyl!";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "My Collection";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit Collection";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete From Collection";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            var image = new Image { Source = "pop.png" };

            Content = stackLayout;

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPopPage());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyCollectionPage());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPopsPage());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeletePopsPage());
        }
    }
}