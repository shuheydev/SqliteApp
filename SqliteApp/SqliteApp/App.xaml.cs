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

//            string dbPath = string.Empty;
//            switch (Device.RuntimePlatform)
//            {
//                case Device.iOS:
//                    dbPath = Path.Combine(Environment.GetFolderPath
//                                (Environment.SpecialFolder.MyDocuments), "..", "Library", "products.db");
//                    break;
//                case Device.Android:
//                    dbPath = Path.Combine(System.Environment.GetFolderPath
//                (System.Environment.SpecialFolder.Personal), "productsDB.db");
//\                    break;
//                case Device.UWP:
//                    //
//                    break;
//            }
//            productsRepository = new ProductsRepository(dbPath);

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
