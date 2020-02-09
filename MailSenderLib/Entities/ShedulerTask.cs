using MailSenderLib.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MailSenderLib.Entities
{
    /// <summary>
    /// Задача планировщика
    /// </summary>
    public class ShedulerTask : BaseEntity
    {
        /// <summary> Время выполнения задания </summary>
        public DateTime Time { get; set; }
        
        /// <summary>Отправитель почты в задании</summary>
        public Sender Sender { get; set; }
        
        /// <summary>Список получателей писем</summary>
        public MailingList Recipients { get; set; }

        /// <summary>Сервер через который надо выполнить отправку почты</summary>
        public Server Server { get; set; }

        /// <summary>Письмо, которое требуется разослать</summary>
        public Mail Mail { get; set; }
    }
}
