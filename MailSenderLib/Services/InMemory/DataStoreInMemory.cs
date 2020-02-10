using MailSenderLib.Data;
using MailSenderLib.Entities;
using MailSenderLib.Entities.Base;
using MailSenderLib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSenderLib.Services
{
    public abstract class DataStoreInMemory<T> : IDataStore<T> where T: BaseEntity
    {
        private readonly List<T> _Items = new List<T>();

        protected DataStoreInMemory(List<T> Items = null) => _Items = Items ?? new List<T>();


        public int Create(T item)
        {
            if (_Items.Contains(item)) return item.Id;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(r => r.Id) + 1;
            _Items.Add(item);
            return item.Id;
        }

        public abstract void Edit(int id, T item);        

        public IEnumerable<T> GetAll() => _Items;

        public T GetByID(int id) => _Items.FirstOrDefault(item => item.Id == id);

        public T Remove(int id)
        {
            var item = GetByID(id);
            if (item != null)
                _Items.Remove(item);
            return item;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище {0}.", typeof(T));
        }
    }
}
