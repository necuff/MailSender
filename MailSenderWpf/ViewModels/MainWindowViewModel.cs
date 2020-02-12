using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib.Entities;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;

namespace MailSenderWpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассыльщик почты";
        private readonly IRecipientsManager _RecipientsManager;
        private ObservableCollection<Recipient> _Recipients;
        private Recipient _SelectedRecipient;

        public MainWindowViewModel(IRecipientsManager RecipientsManager)
        {
            LoadRecipientsDataCommand = new RelayCommand(OnLoadrecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangedCommand = new RelayCommand<Recipient>(OnSaveRecipientChangedCommandExecuted, CanSaveRecipientChangedCommandExecute);
            _RecipientsManager = RecipientsManager;            
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

        public ICommand LoadRecipientsDataCommand { get; }        
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadrecipientsDataCommandExecuted()
        {           
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
        }

        public ICommand SaveRecipientChangedCommand { get; }
        private bool CanSaveRecipientChangedCommandExecute(Recipient recipient)
        {
            System.Diagnostics.Debug.WriteLine("Проверка состояния команды " + recipient?.Name);
            return recipient != null;
        }
        private void OnSaveRecipientChangedCommandExecuted(Recipient recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();
        }
    }
}
