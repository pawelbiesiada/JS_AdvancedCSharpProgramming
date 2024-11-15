using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWpfApp
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ICommand Click { get; set; }

        public string Message { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowVM()
        {

        }
    }
}

