using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace Module
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public ICollection<Contact> Recipients { get; set; } = new HashSet<Contact>();
    }
    //=========================================================================================================================
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Message> MList { get; set; } = new HashSet<Message>();
    }
    //=========================================================================================================================
    public class MessageService
    {
        public ObservableCollection<Message> MessageList { get; set; }
        public ObservableCollection<Contact> ContactList { get; set; }
        public MessageDb MessageData = new MessageDb();

        public MessageService()
        {
            MessageList =  new ObservableCollection<Message>(MessageData.DbMessages);
            ContactList = new ObservableCollection<Contact>(MessageData.DbContacts);
        }

        public void addMessage(Message Message)
        {
            MessageData.DbMessages.Add(Message);
            MessageData.SaveChanges();
            //ContactList = MessageData.DbContacts.ToList();
        }

        public void addContact(Contact Contact)
        {
            MessageData.DbContacts.Add(Contact);
            MessageData.SaveChanges();
            //MessageList = MessageData.DbMessages.ToList();
        }
    }
    //===========================================================================================================================
    public class MessageDb : DbContext
    {
        public DbSet<Message> DbMessages { get; set; }
        public DbSet<Contact> DbContacts { get; set; }

        public MessageDb() : base()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MessageDb>());
        }
    }
}
