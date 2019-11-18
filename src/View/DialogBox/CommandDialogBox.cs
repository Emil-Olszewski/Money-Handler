using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Money_App.View.DialogBox
{
    public class CommandDialogBox : DialogBox
    {
        public override ICommand Show => show ?? (show = new RelayCommand<object>
        (
            o =>
            {
                ExecuteCommand(CommandBefore, CommandParameter);
                execute(o);
                ExecuteCommand(CommandAfter, CommandParameter);
            }
        ));

        public static DependencyProperty CommandParameterProperty 
            = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandDialogBox));

        public object CommandParameter
        {
            get
                => GetValue(CommandParameterProperty);
            set
                => SetValue(CommandParameterProperty, value);
        }

        protected static void ExecuteCommand(ICommand command, object CommandParameter)
        {
            if(command != null)
            {
                if (command.CanExecute(CommandParameter))
                    command.Execute(CommandParameter);
            }
        }

        public static DependencyProperty CommandBeforeProperty =
            DependencyProperty.Register("CommandBefore", typeof(ICommand), typeof(CommandDialogBox));

        public ICommand CommandBefore
        {
            get
                => (ICommand)GetValue(CommandBeforeProperty);
            set
                => SetValue(CommandBeforeProperty, value);
        }

        public static DependencyProperty CommandAfterProperty =
            DependencyProperty.Register("CommandAfter", typeof(ICommand), typeof(CommandDialogBox));

        public ICommand CommandAfter
        {
            get
                => (ICommand)GetValue(CommandAfterProperty);
            set
                => SetValue(CommandAfterProperty, value);
        }

        public class NotificationDialogBox : CommandDialogBox
        {
            public NotificationDialogBox()
            {
                execute = o =>
                {
                    MessageBox.Show((string)o, Caption, MessageBoxButton.OK, MessageBoxImage.Information);
                };
            }
        }
    }
}

