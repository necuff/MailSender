using MailSenderLib.Data;
using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSenderLib.Services
{
    public class RecipientsStoreInMemory : DataStoreInMemory<Recipient>, IRecipientsStore
    {            
        public RecipientsStoreInMemory() : base(TestData.Recipients)
        {

        }

        public override void Edit(int id, Recipient recipient)
        {
            //Делаем вид, что работаем с БД, а не с объектами в памяти            
            //recipient.id <> id, т.к. это разные объекты
            var db_recipient = GetByID(id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;
            db_recipient.Address = recipient.Address;
        }       
    }
}
