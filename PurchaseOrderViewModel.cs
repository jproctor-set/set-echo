using SETEcho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SETEcho
{
    public class PurchaseOrderViewModel : INotifyPropertyChanged
    {
        public PurchaseOrder Order { get; } = new PurchaseOrder();

        public ICommand AddItemCommand { get; }
        public ICommand RemoveItemCommand { get; }


        public PurchaseOrderViewModel()
        {
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
        }

        private void AddItem()
        {
            Order.Items.Add(new PurchaseOrderLine());
            NotifyTotalsChanged();
        }

        private void RemoveItem(object item)
        {
            if (item is PurchaseOrderLine poItem)
            {
                Order.Items.Remove(poItem);
                NotifyTotalsChanged();
            }
        }

        private void NotifyTotalsChanged()
        {
            OnPropertyChanged(nameof(Order));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
