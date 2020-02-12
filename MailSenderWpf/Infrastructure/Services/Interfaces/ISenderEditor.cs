using MailSenderLib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderWpf.Infrastructure.Services.Interfaces
{
    public interface ISenderEditor
    {
        void Edit(Sender sender);
    }
}
