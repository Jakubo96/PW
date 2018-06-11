﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Wozny.PW.BL;
using Wozny.PW.DAO;
using Wozny.PW.INTERFACES;
using WOZNY.PW.VM.Annotations;

namespace WOZNY.PW.VM
{
    public class ProductsListVM : INotifyPropertyChanged
    {
        private IProduct _selectedProduct;

        public IProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                var prevValue = _selectedProduct;
                _selectedProduct = value;

                OnPropertyChanged(nameof(SelectedProduct));

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

        public string Visibility => SelectedProduct == null ? "Hidden" : "Visible";

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
            BusinessLogic.Instance.AddEmptyProduct();
            DownloadProducts();
            OnPropertyChanged(nameof(Products));
            SelectedProduct = Products.Last();
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }
}