using MailSenderLib.Data;
using MailSenderLib.Entities;
using System.Collections.Generic;

namespace MailSenderLib.Services.Interfaces
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
