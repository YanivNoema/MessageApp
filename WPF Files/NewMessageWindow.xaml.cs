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
using System.Windows.Shapes;
using System.ComponentModel;
using Module;


namespace Wpf
{
    public partial class NewMessageWindow : Window
    {
        AddressBookWindow AddressBookWin;
        MessageService MessageServiceHandaler;
        Message NewMessage;

        public NewMessageWindow(MessageService MsgServ)
        {
            InitializeComponent();
            MessageService MessageServiceHandaler = MsgServ;
        }

        private void AddNewContact_Click(object sender, RoutedEventArgs e)
        {
            new AddressBookWindow(MessageServiceHandaler).Show();
        }

        private void DoneBtn_Click(object sender, RoutedEventArgs e)
        {
            NewMessage = new Message { Content = Textbox_Body.Text, Subject = Textbox_Subject.Text};
        }
    }
}
