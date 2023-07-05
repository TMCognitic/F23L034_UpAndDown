using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Observer;

namespace F23L034_UpAndDown.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<int> _items;
        private int _value;
        private ICommand? _incrementCommand, _decrementCommand, _addCommand;

        public int Value
        {
            get => _value;
            set => Set(ref _value, value);
        }

        public ICommand IncrementCommand
        {
            get
            {
                return _incrementCommand ??= new DelegateCommand(Increment, CanIncrement);
            }
        }

        public ICommand DecrementCommand
        {
            get
            {
                return _decrementCommand ??= new DelegateCommand(() => Value--, () => Value > 0);
            }
        }


        public ICommand? AddCommand
        {
            get
            {
                return _addCommand ??= new DelegateCommand(() => Items.Add(Value), null);
            }
        }

        public ObservableCollection<int> Items
        {
            get
            {
                return _items ??= new ObservableCollection<int>();
            }
        }

        public void Increment()
        {
            Value++;
        }

        public bool CanIncrement()
        {
            return Value < 9;
        }
    }
}
