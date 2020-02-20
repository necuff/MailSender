using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailSenderLib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<MailingList> MailingLists { get; set; }
        public DbSet<ShedulerTask> ShedulerTasks { get; set; }            

        public MailSenderDB(DbContextOptions<MailSenderDB> opt) : base(opt)
        {

        }
    }
}
