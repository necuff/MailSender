using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib.Entities;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;
using MailSenderWpf.Infrastructure.Services.Interfaces;

namespace MailSenderWpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассыльщик почты";
        private readonly IRecipientsManager _RecipientsManager;
        private readonly ISendersStore _SendersStore;
        private readonly IServersStore _ServersStore;
        private readonly IMailsStore _MailsStore;
        private readonly ISenderEditor _SenderEditor;





        public MainWindowViewModel(
            IRecipientsManager RecipientsManager,
            ISendersStore SendersStore,
            IServersStore ServersStore,
            IMailsStore MailsStore,
            ISenderEditor SenderEditor
            )
        {
            LoadRecipientsDataCommand = new RelayCommand(OnLoadrecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangedCommand = new RelayCommand<Recipient>(OnSaveRecipientChangedCommandExecuted, CanSaveRecipientChangedCommandExecute);
            SenderEditCommand = new RelayCommand<Sender>(OnSenderEditCommandExecuted, CanSenderEditCommandExecute);
            _RecipientsManager = RecipientsManager;
            _SendersStore = SendersStore;
            _ServersStore = ServersStore;
            _MailsStore = MailsStore;
            _SenderEditor = SenderEditor;
        }

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        
        private ObservableCollection<Recipient> _Recipients;
        
        public ObservableCollection<Recipient> Recipients 
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }


        private ObservableCollection<Sender> _Senders;

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }

        private ObservableCollection<Server> _Servers;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }

        private ObservableCollection<Mail> _Mails;

        public ObservableCollection<Mail> Mails
        {
            get => _Mails;
            private set => Set(ref _Mails, value);
        }
        
        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }


        private Sender _SelectedSender;
        private Server _SelectedServer;
        private Mail _SelectedMail;

        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value);
        }

        public ICommand LoadRecipientsDataCommand { get; }        
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadrecipientsDataCommandExecuted()
        {           
            Recipients = new ObservableCollection<Recipient>(_RecipientsManager.GetAll());
            
            Senders = new ObservableCollection<Sender>(_SendersStore.GetAll());
            Servers = new ObservableCollection<Server>(_ServersStore.GetAll());
            Mails = new ObservableCollection<Mail>(_MailsStore.GetAll());

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

        public ICommand SenderEditCommand { get; }
        private bool CanSenderEditCommandExecute(Sender sender) => sender != null;        
        private void OnSenderEditCommandExecuted(Sender sender)
        {
            _SenderEditor.Edit(sender);
        }
    }
}
