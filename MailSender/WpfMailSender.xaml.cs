using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            //Список получателей
            List<string> listStrMails = new List<string> { "necuff87@gmail.com" };  

            //EmailSendServiceClass es = new EmailSendServiceClass("necuff87@yandex.ru", "Привет из C#", "Hello, world!", listStrMails, "necuff87@yandex.ru", passwordBox.Password);


            //Метод возвращает текст ошибки, либо пустую строку
            string result = string.Empty;
            //result = es.Send();

            SendEndWindow sew;
            if (result == string.Empty)
            {
               sew = new SendEndWindow("Сообщение отправлено!");               
            }
            else
            {
                sew = new SendEndWindow("Работа завершена", Colors.Red);                
            }
            sew.ShowDialog();
        }
    }
}
