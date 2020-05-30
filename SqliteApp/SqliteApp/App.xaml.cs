using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteApp
{
    public partial class App : Application
    {
        public App(IProductsRepository productsRepository)
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new ProductsPage()
            {
                BindingContext = new ProductsViewModel(productsRepository),
            };
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
