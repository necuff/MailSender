using MailSenderLib.Data.EF;
using MailSenderLib.Entities;
using MailSenderLib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSenderLib.Services.EF
{
    public class RecipientsStoreEF : IRecipientsStore
    {
        private readonly MailSenderDB _db;

        public RecipientsStoreEF(MailSenderDB db) => _db = db;

        public int Create(Recipient item)
        {
            _db.Recipients.Add(item);
            SaveChanges();
            return item.Id;
        }
       

        public void Edit(int id, Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = GetByID(id);
            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();

        }

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();


        public Recipient GetByID(int id) => _db.Recipients.FirstOrDefault(r => r.Id == id);
        
        public Recipient Remove(int id)
        {
            var db_item = GetByID(id);
            if (db_item is null) return null;
            //_db.Recipients.Remove(db_item);

            _db.Entry(db_item).State = EntityState.Deleted;
            SaveChanges();

            return db_item;
        }

        public void SaveChanges() => _db.SaveChanges();
       
    }
}
