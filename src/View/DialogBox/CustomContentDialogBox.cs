using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Money_App.View.DialogBox
{
    [ContentProperty("WindowContent")]
    public class CustomContentDialogBox : CommandDialogBox
    {
        private bool? LastResult;

        public double WindowWidth { get; set; } = 640;
        public double WindowHeight { get; set; } = 480;
        public object WindowContent { get; set; } = null;

        private static Window window = null;

        public CustomContentDialogBox()
        {
            execute = o =>
            {
                window = new Window
                {
                    Width = WindowWidth,
                    Height = WindowHeight,
                    Title = Caption,
                    Content = WindowContent
                };

                LastResult = window.ShowDialog();
                OnPropertyChanged("LastResult");

                window = null; 
                switch(LastResult)
                {
                    case true:
                        ExecuteCommand(CommandTrue, CommandParameter);
                        break;
                    case false:
                        ExecuteCommand(CommandFalse, CommandParameter);
                        break;
                    case null:
                        ExecuteCommand(CommandNull, CommandParameter);
                        break;
                }
            };
        }

        public static bool? GetCustomContentDialogResult(DependencyObject d)
            => (bool?)d.GetValue(DialogResultProperty);

        public static void SetCustomContentDialogResult(DependencyObject d, bool? value)
            => d.SetValue(DialogResultProperty, value);

        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(CustomContentDialogBox), new PropertyMetadata(null, DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool? dialogResult = (bool?)e.NewValue;
            if(d is Button)
            {
                var button = d as Button;
                button.Click +=
                    (object sender, RoutedEventArgs _e) =>
                    {
                        window.DialogResult = dialogResult;
                    };
            }
        }

        public static DependencyProperty CommandTrueProperty =
            DependencyProperty.Register("CommandTrue", typeof(ICommand), typeof(CustomContentDialogBox));
        
        public ICommand CommandTrue
        {
            get
            {
                return (ICommand)GetValue(CommandTrueProperty);
            }
            set
            {
                SetValue(CommandTrueProperty, value);
            }
        }

        public static DependencyProperty CommandFalseProperty =
             DependencyProperty.Register("CommandFalse", typeof(ICommand), typeof(CustomContentDialogBox));

        public ICommand CommandFalse
        {
            get
            {
                return (ICommand)GetValue(CommandFalseProperty);
            }
            set
            {
                SetValue(CommandFalseProperty, value);
            }
        }

        public static DependencyProperty CommandNullProperty =
            DependencyProperty.Register("CommandNull", typeof(ICommand), typeof(CustomContentDialogBox));

        public ICommand CommandNull
        {
            get
            {
                return (ICommand)GetValue(CommandNullProperty);
            }
            set
            {
                SetValue(CommandNullProperty, value);
            }
        }

    }
}
