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
        private IProducer _selectedProducer;

        public IProducer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                var prevValue = _selectedProducer;
                _selectedProducer = value;

                OnPropertyChanged(nameof(SelectedProducer));

                if (prevValue == null || value == null)
                    OnPropertyChanged(nameof(Visibility));

                if (value != null && (prevValue != null && prevValue.Name != value.Name))
                    OnPropertyChanged(nameof(Producers));
            }
        }

        public ObservableCollection<IProducer> Producers { get; private set; }
        public ICommand RemoveItemCommand => new Command(RemoveItem);
        public ICommand AddItemCommand => new Command(AddItem);

        public string Visibility => SelectedProducer == null ? "Hidden" : "Visible";


        public ProducersListVM()
        {
            DownloadProducers();
        }

        private void DownloadProducers()
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
            {
                BusinessLogic.Instance.RemoveProducer(SelectedProducer);
                Producers.Remove(SelectedProducer);
            }
            else
                MessageBox.Show("Nie wybrano żadnego elementu", "Uwaga!");
        }

        private void AddItem()
        {
            BusinessLogic.Instance.AddEmptyProducer();
            DownloadProducers();
            OnPropertyChanged(nameof(Producers));
            SelectedProducer = Producers.Last();
            OnPropertyChanged(nameof(SelectedProducer));
        }
    }
}