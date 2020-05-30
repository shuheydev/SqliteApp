using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteApp
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private readonly IProductsRepository _productsRepository;
        //private IEnumerable<Product> _products;
        //public IEnumerable<Product> Products
        //{
        //    get
        //    {
        //        return _products;
        //    }
        //    set
        //    {
        //        _products = value;
        //        OnPropertyChanged();
        //    }
        //}

        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public decimal ProductPrice { get; set; }
        public string ProductTitle { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Products=new ObservableCollection<Product>(await _productsRepository.GetProductAsync());
                });
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var product = new Product
                        {
                            Title = ProductTitle,
                            Price = ProductPrice,
                        };
                        var result = await _productsRepository.AddProductAsync(product);
                        if (result)
                        {
                            this.Products.Add(product);
                        }
                    }
                    catch (Exception e)
                    {

                    }
                });
            }
        }

        public ProductsViewModel(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
