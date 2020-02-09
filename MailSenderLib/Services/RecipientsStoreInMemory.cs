using MailSenderLib.Data;
using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSenderLib.Services
{
    public class RecipientsStoreInMemory : IRecipientsStore
    {
        public IEnumerable<Recipient> GetAll() => TestData.Recipients;
        
        public void Edit(int id, Recipient recipient)
        {
            //Делаем вид, что работаем с БД, а не с объектами в памяти            
            //recipient.id <> id, т.к. это разные объекты
            var db_recipient = GetByID(id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;
            db_recipient.Address = recipient.Address;
        }

        public Recipient GetByID(int id) => TestData.Recipients.FirstOrDefault(r => r.Id == id);

        public int Create(Recipient Recipient)
        {
            if (TestData.Recipients.Contains(Recipient)) return Recipient.Id;
            Recipient.Id = TestData.Recipients.Count == 0 ? 1 : TestData.Recipients.Max(r => r.Id) + 1;
            TestData.Recipients.Add(Recipient);
            return Recipient.Id;
        }

        public Recipient Remove(int id)
        {
            var db_recipient = GetByID(id);
            if(db_recipient != null)
                TestData.Recipients.Remove(db_recipient);
            return db_recipient;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище получателей писем.");
            //Т.к. это хранилище данных в памяти, то здесь ничего не делаем
        }
    }
}
