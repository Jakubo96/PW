using System;
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
using Wozny.PW.INTERFACES;
using WOZNY.PW.VM.Annotations;

namespace WOZNY.PW.VM
{
    public class ProductsListVM : INotifyPropertyChanged
    {
        public IProduct SelectedProduct { get; set; }
        public ObservableCollection<IProduct> Products { get; }
        public ICommand RemoveItemCommand => new Command(RemoveItem);

        public ProductsListVM()
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
                Products.Remove(SelectedProduct);
            else
                MessageBox.Show("Nie wybrano żadnego elementu");
        }
    }
}