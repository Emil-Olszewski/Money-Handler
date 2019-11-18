using System;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;

namespace Money_App.View.DialogBox
{
    public abstract class DialogBox : FrameworkElement, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected Action<object> execute = null;
        public string Caption { get; set; }

        protected ICommand show;
        public virtual ICommand Show 
            => show ?? (show = new RelayCommand<object>(execute));
    }
}
