using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wozny.PW.BL;
using Wozny.PW.INTERFACES;

namespace WOZNY.PW.WPF_UI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IEnumerable<IProduct> Products { get; }
        public IEnumerable<IProducer> Producers { get; }

        public MainWindow()
        {
            ConfigInjector.InjectDllNameToBL();

            Products = BusinessLogic.Instance.GetAllProducts();
            Producers = BusinessLogic.Instance.GetAllProducers();

            InitializeComponent();
            DataContext = this;
        }
    }
}