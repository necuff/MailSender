using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System.Collections.Generic;

namespace MailSenderLib.Services
{
    public class RecipientsManager : IRecipientsManager
    {
        private IRecipientsStore _Store;

        public RecipientsManager(IRecipientsStore Store)
        {
            _Store = Store;
        }


        public IEnumerable<Recipient> GetAll()
        {
            return _Store.GetAll();
        }

        public void Add(Recipient NewRecipient)
        {

        }

        public void Edit(Recipient Recipient)
        {
            _Store.Edit(Recipient.Id, Recipient);
        }

        public void SaveChanges()
        {
            _Store.SaveChanges();
        }


        //Delete(Recipient)
    }
}
