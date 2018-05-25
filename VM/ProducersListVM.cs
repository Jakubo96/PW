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
using Wozny.PW.DAO;
using Wozny.PW.INTERFACES;
using WOZNY.PW.VM.Annotations;

namespace WOZNY.PW.VM
{
    public class ProducersListVM : INotifyPropertyChanged
    {
        public IProducer SelectedProducer { get; set; }
        public ObservableCollection<IProducer> Producers { get; }
        public ICommand RemoveItemCommand => new Command(RemoveItem);


        public ProducersListVM()
        {
            Producers = new ObservableCollection<IProducer>(BusinessLogic.Instance.GetAllProducers());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RemoveItem()
        {
            if (SelectedProducer != null)
                Producers.Remove(SelectedProducer);
            else
                MessageBox.Show("Nie wybrano żadnego elementu");
        }
    }
}