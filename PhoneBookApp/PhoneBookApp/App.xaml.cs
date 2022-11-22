
using FluentValidation;
using FreshMvvm;
using PhoneBookApp.Helpers;
using PhoneBookApp.PageModel;
using PhoneBookApp.Services;
using PhoneBookApp.Validator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneBookApp
{
    public partial class App : Application
    {
        public App()
        {
            //Setting up IOC
            FreshIOC.Container.Register<IPhoneBookRepository, PhoneBookRepository>();
            FreshIOC.Container.Register<IValidator, PersonValidator>();

            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            var navigationPage = new FreshNavigationContainer(page);
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
