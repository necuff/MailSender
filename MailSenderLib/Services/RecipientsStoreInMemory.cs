using MailSenderLib.Data;
using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System.Collections.Generic;

namespace MailSenderLib.Services
{
    public class RecipientsStoreInMemory : IRecipientsStore
    {
        public IEnumerable<Recipient> Get() => TestData.Recipients;
        
        public void Edit(int id, Recipient recipient)
        {
            //Т.к. это хранилище данных в памяти, то здесь ничего не делаем
        }

        public void SaveChanges()
        {
            //Т.к. это хранилище данных в памяти, то здесь ничего не делаем
        }
    }

    
}
