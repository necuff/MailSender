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
using MailSenderLib.MVVM;
using System.Threading;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window 
    { 
        public WpfMailSender() => InitializeComponent();

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            const string message = "KIjfkdsjf";

            var result = GetMessageLenght(message);

            Result.Text = result.ToString();
        }

        private int _StartCount;
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private Task<int> GetMessageLenghtAsync(string Message, int Timeout = 30)
        {
            return Task.Run(() => GetMessageLenght(Message, Timeout));
        }

        private int GetMessageLenght(string Message, int Timeout = 30)
        {
            for (int i = 0; i < 100; i++)
                Thread.Sleep(Timeout);
            return Message.Length + _StartCount++;
        }
    }
}
