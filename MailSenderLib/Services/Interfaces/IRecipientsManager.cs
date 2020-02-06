using MailSenderLib.Entities;
using System.Collections.Generic;

namespace MailSenderLib.Services.Interfaces
{
    public interface IRecipientsManager
    {
        IEnumerable<Recipient> GetAll();

        void Add(Recipient NewRecipient);

        void Edit(Recipient Recipient);

        void SaveChanges()
    }    
}
