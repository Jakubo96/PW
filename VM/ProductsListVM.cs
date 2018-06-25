using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wozny.PW.BL;
using Wozny.PW.DAO;
using Wozny.PW.INTERFACES;
using WOZNY.PW.VM.Annotations;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WOZNY.PW.VM
{
    public class ProductsListVM : INotifyPropertyChanged
    {
        private IProduct _productToConfirm;

        private IProduct _selectedProduct;

        public IProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                var prevValue = _selectedProduct;
                _selectedProduct = value;

                OnPropertyChanged(nameof(SelectedProduct));
                OnPropertyChanged(nameof(ConfirmVisibility));

                if (prevValue == null || value == null)
                    OnPropertyChanged(nameof(Visibility));

                if (value != null && (prevValue != null &&
                                      (prevValue.Producer.Name != value.Producer.Name ||
                                       prevValue.Model != value.Model)))
                    OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<IProduct> Products { get; private set; }
        public ICommand RemoveItemCommand => new Command(RemoveItem);
        public ICommand AddItemCommand => new Command(AddItem);
        public ICommand ConfirmItemCommand => new Command(ConfirmProduct);

        public string Visibility => SelectedProduct == null ? "Hidden" : "Visible";

        public string ConfirmVisibility =>
            _productToConfirm != null && _productToConfirm == SelectedProduct ? "Visible" : "Hidden";

        public ProductsListVM()
        {
            DownloadProducts();
        }

        private void DownloadProducts()
        {
            Products = new ObservableCollection<IProduct>(BusinessLogic.Instance.GetAllProducts());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RemoveItem()
        {
            if (SelectedProduct != null)
            {
                BusinessLogic.Instance.RemoveProduct(SelectedProduct);
                Products.Remove(SelectedProduct);
            }
            else
                MessageBox.Show("Nie wybrano żadnego elementu", "Uwaga!");
        }

        private void AddItem()
        {
            if (_productToConfirm != null)
            {
                Products.Remove(_productToConfirm);
            }

            Products.Add(new Product(new Producer(), new Drive()));
            SelectedProduct = Products.Last();
            _productToConfirm = SelectedProduct;

            OnPropertyChanged(nameof(ConfirmVisibility));
            OnPropertyChanged(nameof(SelectedProduct));
        }

        private void ConfirmProduct()
        {
            BusinessLogic.Instance.AddProduct(_productToConfirm);
            _productToConfirm = null;
            OnPropertyChanged(nameof(ConfirmVisibility));
        }
    }
}