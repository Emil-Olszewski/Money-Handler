using System.Windows;
using System.Windows.Input;

namespace Money_App.View.DialogBox
{
    public class MessageDialogBox : CommandDialogBox
    {
        public MessageBoxResult? LastResult { get; protected set; }
        public MessageBoxButton Buttons { get; set; } = MessageBoxButton.OK;
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

        public bool IsLastResultYes
            => LastResult.HasValue && LastResult.Value == MessageBoxResult.Yes;

        public bool IsLastResultNo
            => LastResult.HasValue && LastResult.Value == MessageBoxResult.No;

        public bool IsLastResultCancel
            => LastResult.HasValue && LastResult.Value == MessageBoxResult.Cancel;

        public bool IsLastResultOK
            => LastResult.HasValue && LastResult.Value == MessageBoxResult.OK;

        public MessageDialogBox()
        {
            execute = o =>
            {
                LastResult = MessageBox.Show((string)o, Caption, Buttons, Icon);
                OnPropertyChanged("LastResult");
                switch (LastResult)
                {
                    case MessageBoxResult.Yes:
                        OnPropertyChanged("IsLastResultYes");
                        ExecuteCommand(CommandYes, CommandParameter);
                        break;

                    case MessageBoxResult.No:
                        OnPropertyChanged("IsLastResultNo");
                        ExecuteCommand(CommandNo, CommandParameter);
                        break;

                    case MessageBoxResult.Cancel:
                        OnPropertyChanged("IsLastResultCancel");
                        ExecuteCommand(CommandCancel, CommandParameter);
                        break;

                    case MessageBoxResult.OK:
                        OnPropertyChanged("IsLastResultOK");
                        ExecuteCommand(CommandOK, CommandParameter);
                        break;
                }
            };
        }

        public static DependencyProperty CommandYesProperty =
            DependencyProperty.Register("CommandYes", typeof(ICommand), typeof(MessageDialogBox));

        public ICommand CommandYes
        {
            get
                => (ICommand)GetValue(CommandYesProperty);
            set
                => SetValue(CommandYesProperty, value);
        }

        public static DependencyProperty CommandNoProperty =
            DependencyProperty.Register("CommandNo", typeof(ICommand), typeof(MessageDialogBox));

        public ICommand CommandNo
        {
            get
                => (ICommand)GetValue(CommandNoProperty);
            set
                => SetValue(CommandNoProperty, value);
        }

        public static DependencyProperty CommandCancelProperty =
            DependencyProperty.Register("CommandCancel", typeof(ICommand), typeof(MessageDialogBox));

        public ICommand CommandCancel
        {
            get
                => (ICommand)GetValue(CommandCancelProperty);
            set
                => SetValue(CommandCancelProperty, value);
        }

        public static DependencyProperty CommandOKProperty =
            DependencyProperty.Register("CommandOK", typeof(ICommand), typeof(MessageDialogBox));

        public ICommand CommandOK
        {
            get
                => (ICommand)GetValue(CommandOKProperty);
            set
                => SetValue(CommandOKProperty, value);
        }
    }
}
