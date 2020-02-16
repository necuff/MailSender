using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using System.Linq;

namespace MailSenderLib.Services
{
    public class MailsStoreInMemory : DataStoreInMemory<Mail>, IMailsStore
    {
        public MailsStoreInMemory() : base(Enumerable.Range(1, 10).Select(i => new Mail { Id = i, Subject = $"Message {i}", Body = $"MEssage body {i}"}).ToList())
        {

        }

        public override void Edit(int id, Mail mail)
        {
            //Делаем вид, что работаем с БД, а не с объектами в памяти            
            //mail.id <> id, т.к. это разные объекты
            var db_mail = GetByID(id);
            if (db_mail is null) return;

            db_mail.Subject = mail.Subject;
            db_mail.Body = mail.Body;
        }
    }
}
