using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zadatko.Helpers;

namespace Zadatko.Pages
{
    public class FirstPage:ContentPage
    {
        public FirstPage()
        {
            var image = new Image()
            {
                Source = ImageSource.FromFile("icon.png")
            };

            var label = new Label()
            {
                Text =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                LineBreakMode = LineBreakMode.WordWrap
            };

            var termsButton = new Button()
            {
                Text = "Show Terms"
            };
            termsButton.Clicked += TermsButton_Clicked;

            var agreeButton = new Button()
            {
                Text = "I Agree"
            };
            agreeButton.Clicked += AgreeButton_Clicked;

            var disagreeButton = new Button()
            {
                Text = "I Disagree"
            };
            disagreeButton.Clicked += DisagreeButton_Clicked;


            Content = new StackLayout()
            {
                Children = {image, label, termsButton, agreeButton, disagreeButton}
            };
        }

        private void DisagreeButton_Clicked(object sender, EventArgs e)
        {
            this.SendBackButtonPressed();
        }

        private void AgreeButton_Clicked(object sender, EventArgs e)
        {
            //var page = Navigation.NavigationStack.FirstOrDefault(x => x.GetType() == typeof (FirstPage));
            Navigation.InsertPageBefore(new ZadatkoTabbedPage(), this);
            Settings.Accepted = true;
            Navigation.PopAsync();
        }

        private void TermsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TermsPage());
        }
    }
}
