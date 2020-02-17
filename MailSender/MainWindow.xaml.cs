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

        private CancellationTokenSource _ProcessCancelation;

        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;
            button.IsEnabled = false;

            var cancellation = new CancellationTokenSource();
            _ProcessCancelation?.Cancel();            
            _ProcessCancelation = cancellation;
            
            Result.Text = "Запуск операции";
            const string message = "KIjfkdsjf";
            
            IProgress<int> progress = new Progress<int>(p => _Progress.Value = p);

            try
            {
                var result = await GetMessageLenghtAsync(message, 30, progress, cancellation.Token);

                progress.Report(0);

                Result.Text = result.ToString();
            }

            catch (OperationCanceledException ex)
            {
                Result.Text = "Отмена операции";
                progress.Report(0);
            }
            button.IsEnabled = true;

        }

        private int _StartCount;
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            _ProcessCancelation.Cancel();
        }

        private Task<int> GetMessageLenghtAsync(string Message, int Timeout = 30, IProgress<int> Progress = null, CancellationToken Cancel = default)
        {
            return Task.Run(() => GetLenghtAsync(Message, Timeout, Progress, Cancel), Cancel);
        }

        private int GetMessageLenght(string Message, int Timeout = 30, IProgress<int> Progress = null, CancellationToken Cancel = default)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(Timeout);
                Progress?.Report(i);

                Cancel.ThrowIfCancellationRequested();
            }
                
            return Message.Length + _StartCount++;
        }

        private async Task<int> GetLenghtAsync(string Message, int Timeout = 30, IProgress<int> Progress = null, CancellationToken Cancel = default)
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(Timeout, Cancel);

                Progress?.Report(i);
                
                Cancel.ThrowIfCancellationRequested();
            }

            return Message.Length + _StartCount++;
        }
    }
}
