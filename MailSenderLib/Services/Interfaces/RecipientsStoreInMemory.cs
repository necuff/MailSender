using MailSenderLib.Data;
using MailSenderLib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.Interfaces
{
    public class RecipientsStoreInMemory
    {
        public IEnumerable<Recipient> Get() => TestData.Recipients;
    }
}
