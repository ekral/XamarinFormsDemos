using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellDemo
{
    public partial class App : Application
    {
        private static Model.EshopDatabase _databaze;

        public static Model.EshopDatabase Databaze
        {
            get 
            { 
                if(_databaze == null)
                {
                    _databaze = new Model.EshopDatabase("data.db3");
                    _databaze.EnsureCreated().Wait();
                }

                return _databaze; 
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new View.AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
