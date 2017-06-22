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
using System.Collections.ObjectModel;

namespace Wpf
{

    public partial class AddressBookWindow : Window
    {
        String str;
        MessageService MessageServiceHandaler;
        AddNewContactWindow AddNewContactWin;

        public AddressBookWindow(MessageService MsgServ)
        {
            InitializeComponent();
            MessageServiceHandaler = MsgServ;
            displayRecp.ItemsSource = MsgServ.ContactList;
            AddNewContactWin = new AddNewContactWindow(MsgServ);
        }

        private void selectedRecp(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void AddNewContact_Click(object sender, RoutedEventArgs e)
        {
            AddNewContactWin.Show();
        }

        private void Contacts_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCollectionView ListT = new ListCollectionView(MessageServiceHandaler.ContactList);
            str = Textbox_Users.Text;
            ListT.Filter = recpFilter;
            displayRecp.ItemsSource = ListT;
        }

        private bool recpFilter(object item)
        {
            Contact FilteredContact = item as Contact;
            return FilteredContact.Name.StartsWith(str);
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            this.Hide();
        }
    }
}
