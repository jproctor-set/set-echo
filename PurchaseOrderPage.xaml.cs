using SETEcho.Data;
using SETEcho.Data.Models;
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

namespace SETEcho
{
    /// <summary>
    /// Interaction logic for PurchaseOrderPage.xaml
    /// </summary>
    public partial class PurchaseOrderPage : Page
    {

        private readonly AppDbContext _db = new AppDbContext();

        public PurchaseOrderPage()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var rows = await _db.PurchaseOrders.ToListAsync();
            DataGridPO.ItemsSource = rows;
        }

    }
}
