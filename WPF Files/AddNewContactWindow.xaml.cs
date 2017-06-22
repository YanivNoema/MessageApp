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
    public partial class AddNewContactWindow : Window
    {
        Contact NewContact;
        MessageService MessageServiceHandaler;

        public AddNewContactWindow(MessageService MsgServ)
        {
            InitializeComponent();
            MessageServiceHandaler = MsgServ;
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            //check if email ig correct
            if (!(Textbox_Subject.Text == String.Empty) || !(Textbox_Email.Text == String.Empty))
                NewContact = new Contact { Name = Textbox_Subject.Text, Email = Textbox_Email.Text };
            MessageServiceHandaler.addContact(NewContact);
            this.Close();
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            this.Hide();
        }
    }
}
