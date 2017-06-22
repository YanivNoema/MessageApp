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
using System.ComponentModel;
using Module;

namespace Wpf
{

    public partial class MainWindow : Window
    {

        NewMessageWindow NewMessageWin;
        MessageService MessageServeiceHandaler;
  
        public MainWindow()
        {
            InitializeComponent();
            MessageServeiceHandaler = new MessageService();
            DisplayMessageBox.ItemsSource = MessageServeiceHandaler.MessageList;
            Closing += OnClosing;
            NewMessageWin = new NewMessageWindow(MessageServeiceHandaler);
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (MessageBox.Show(this, "Discard Message?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                cancelEventArgs.Cancel = true;
            }
        }

        private void selectedMessage(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DisplayMessageBox.SelectedItem != null)
            {
                Message MessageToShow = (Message)DisplayMessageBox.SelectedItem;
                Textbox_Subject.Text = MessageToShow.Subject;
                Textbox_date.Text = MessageToShow.Time.ToString();
                Textbox_content.Text = MessageToShow.Content;
                DisplayRecp.ItemsSource = MessageToShow.Recipients; 
            }
        }

        private void NewMessage_Click(object sender, RoutedEventArgs e)
        {
            NewMessageWin = new NewMessageWindow(MessageServeiceHandaler);
            NewMessageWin.ShowDialog();
        }

        private void MessageDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}