using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinPluginTestHarness
{
    public class App
    {
        public static Page GetMainPage()
        {
            StackLayout layout = new StackLayout();
            Button btnOn = new Button();
            btnOn.Text = "Lamp ON";
            layout.Children.Add(btnOn);
            btnOn.Clicked += btnOn_Clicked;

            Button btnOff = new Button();
            btnOff.Text = "Lamp OFF";
            layout.Children.Add(btnOff);
            btnOff.Clicked += btnOff_Clicked;

            return new ContentPage { Content = layout };
        }

        static void btnOff_Clicked(object sender, EventArgs e)
        {
            Lamp.Plugin.CrossLamp.Current.TurnOff();
        }

        static void btnOn_Clicked(object sender, EventArgs e)
        {
            Lamp.Plugin.CrossLamp.Current.TurnOn();
        }
    }
}
