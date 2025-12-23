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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SETEcho.Models;

namespace SETEcho
{
    /// <summary>
    /// Interaction logic for PurchaseOrderPage.xaml
    /// </summary>
    public partial class PurchaseOrderPage : Page
    {

        private readonly SETEchoContext _db = new SETEchoContext();

        public ICommand RefreshCommand { get; }

        public PurchaseOrderPage()
        {
            InitializeComponent();
            RefreshCommand = new RelayCommand(_ => LoadData());
            LoadData();
        }

        private async void LoadData()
        {
            var rows = await _db.PurchaseOrder
                .Include(po => po.Supplier)
                .Include(po => po.UpdatedByUser)
                .ToListAsync();

            DataGridPO.ItemsSource = rows;
        }


    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged;
    }
}
