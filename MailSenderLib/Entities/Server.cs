using MailSenderLib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Entities
{
    /// <summary>
    /// Почтовый сервер
    /// </summary>
    public class Server : NamedEntity
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; } = true;
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
