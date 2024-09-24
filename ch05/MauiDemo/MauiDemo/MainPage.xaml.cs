using Microsoft.Maui.Controls;

namespace MauiDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            MessageLabel.Text = "You clicked the button!";
        }
    }
}