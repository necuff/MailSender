using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> emails;
        private string Login { get; }
        private string Password { get; }
        
        public EmailSendServiceClass(string sender, string subject, string body, List<string> addressList, string login, string password)
        {
            Sender = sender;
            Subject = subject;
            Body = body;
            emails = addressList;
            Login = login;
            Password = password;
        }

        public string Send()
        {            
            foreach (string mail in emails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(Sender, mail))
                {
                    // Формируем письмо
                    mm.Subject = Subject;   // Заголовок письма
                    mm.Body = Body;         // Тело письма
                    mm.IsBodyHtml = false;  // Не используем html в теле письма

                    // Авторизуемся на smtp-сервере и отправляем письмо
                    // Оператор using гарантирует вызов метода Dispose, даже если при вызове методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient(SMTPParams.host, SMTPParams.port))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(Login, Password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            return ex.ToString();
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
