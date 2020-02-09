using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System.Collections.Generic;

namespace MailSenderLib.Services
{
    public class RecipientsManager : IRecipientsManager
    {
        private IRecipientsStore _Store;

        public RecipientsManager(RecipientsStoreInMemory Store)
        {
            _Store = Store;
        }


        public IEnumerable<Recipient> GetAll()
        {
            return _Store.Get();
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


        //Edit(Recipient)
        //Delete(Recipient)
    }
}
