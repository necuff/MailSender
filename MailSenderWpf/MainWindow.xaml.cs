using MailSenderLib.Entities;
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
using MailSenderLib.Service;

namespace MailSenderWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object Sender, RoutedEventArgs e)
        {
            var recipient = dgRecipientsList.SelectedItem as Recipient;
            var sender = cbSenderList.SelectedItem as Sender;
            var server = cbServersList.SelectedItem as Server;

            if (recipient is null || sender is null || server is null) return;

            var mail_sender = new MailSenderLib.Services.MailSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password.Decode(3));

            mail_sender.Send(tbMailHeader.Text, tbMailBody.Text, sender.Address, recipient.Address);
        }     
    }
}
