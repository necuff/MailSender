using MailSenderLib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Entities
{
    public class MailingList : NamedEntity
    {
        public ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();
    }
}
