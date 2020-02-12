using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MailSenderLib.Entities.Base;

namespace MailSenderLib.Entities
{
    public class Recipient : PersonEntity, IDataErrorInfo
    {
        public override string Name 
        { 
            get => base.Name;
            set
            {
                if (value == "Иванов123")
                    throw new ArgumentException("Иванов123 нам не подходит", nameof(value));
                base.Name = value;
            }
        }

        string IDataErrorInfo.this[string PropertyName] 
        { 
            get
            {
                switch (PropertyName)
                {
                    default: return null;
                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Пустыя ссылка на имя";
                        if (name.Length <= 2) return "Имя должно быть длиннее двух символов";
                        if (name.Length > 20) return "Длина имени должна быть не больше 20 символов";

                        return null;                        
                }
            }
        }

        string IDataErrorInfo.Error => null;
    }
}
