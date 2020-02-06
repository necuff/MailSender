using MailSenderLib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipient> Get();

        void Edit(int id, Recipient recipient);

        void SaveChanges();
    }
}
