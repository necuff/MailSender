using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using MailSenderLib.Entities;
using MailSenderLib.Services;

namespace MailSenderWpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассыльщик почты";
        private readonly RecipientsManager _RecipientsManager;
        private ObservableCollection<Recipient> _Recipients;
        private Recipient _SelectedRecipient;

        public MainWindowViewModel(RecipientsManager RecipientsManager)
        {
            _RecipientsManager = RecipientsManager;
            _Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        
        public ObservableCollection<Recipient> Recipients 
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
    }
}
