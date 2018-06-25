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
        private IProducer _producerToConfirm;

        private IProducer _selectedProducer;

        public IProducer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                var prevValue = _selectedProducer;
                _selectedProducer = value;

                OnPropertyChanged(nameof(SelectedProducer));
                OnPropertyChanged(nameof(ConfirmVisibility));

                if (prevValue == null || value == null)
                    OnPropertyChanged(nameof(Visibility));

                if (value != null && (prevValue != null && prevValue.Name != value.Name))
                    OnPropertyChanged(nameof(Producers));
            }
        }

        public ObservableCollection<IProducer> Producers { get; private set; }
        public ICommand RemoveItemCommand => new Command(RemoveItem);
        public ICommand AddItemCommand => new Command(AddItem);

        public ICommand ConfirmProducerCommand => new Command(ConfirmProducer);

        public string Visibility => SelectedProducer == null ? "Hidden" : "Visible";

        public string ConfirmVisibility =>
            _producerToConfirm != null && _producerToConfirm == SelectedProducer ? "Visible" : "Hidden";


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
            if (_producerToConfirm != null)
            {
                Producers.Remove(_producerToConfirm);
            }

            Producers.Add(new Producer());
            SelectedProducer = Producers.Last();
            _producerToConfirm = SelectedProducer;
            OnPropertyChanged(nameof(ConfirmVisibility));
            OnPropertyChanged(nameof(SelectedProducer));
        }

        private void ConfirmProducer()
        {
            BusinessLogic.Instance.AddProducer(_producerToConfirm);

            _producerToConfirm = null;
            OnPropertyChanged(nameof(ConfirmVisibility));
        }
    }
}