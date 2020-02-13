using MailSenderLib.Entities;
using System.Diagnostics;

namespace MailSenderLib.Services
{
    public class MailSenderDebug
    {
        private Server _Server;

        public MailSenderDebug(Server Server) => _Server = Server;
        
        public void Send(Mail Mail, Sender From, Recipient To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}",
                From.Address, To.Address,
                _Server.Address, _Server.Port, _Server.UseSSL ? "SSL" : "no SSL",
                Mail.Subject, Mail.Body);
        }
    }

}
