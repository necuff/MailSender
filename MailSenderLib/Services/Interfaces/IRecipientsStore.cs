using MailSenderLib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        //Получить всех получателей
        IEnumerable<Recipient> GetAll();

        //Получить получателя по id
        Recipient GetByID(int id);

        //Создать нового получателя
        int Create(Recipient Recipient);

        //Редактировать получателя
        void Edit(int id, Recipient recipient);

        //Удалить получателя
        Recipient Remove(int id);

        //Сохранить изменения
        void SaveChanges();
    }
}
