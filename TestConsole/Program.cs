using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MailMessage mm = new MailMessage("necuff87@yandex.ru", "necuff87@gmail.com");
            mm.Subject = "Заголовок";
            mm.Body = "Тело письма";
            mm.IsBodyHtml = false;

            SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential("necuff87@yandex.ru", "");
            try
            {
                sc.Send(mm);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Невозможно отправить письмо. " + ex.ToString());
            }
        }
    }
}
