using MailSenderLib.Data;
using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services
{
    public class SendersStoreInMemory : DataStoreInMemory<Sender>, ISendersStore
    {
        public SendersStoreInMemory() : base(TestData.Senders)
        {

        }

        public override void Edit(int id, Sender sender)
        {
            //Делаем вид, что работаем с БД, а не с объектами в памяти            
            //sender.id <> id, т.к. это разные объекты
            var db_sender = GetByID(id);
            if (db_sender is null) return;

            db_sender.Name = sender.Name;
            db_sender.Address = sender.Address;
        }
    }
}
