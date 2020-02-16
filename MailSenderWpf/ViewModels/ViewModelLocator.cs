using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;
using MailSenderWpf.Infrastructure.Services;
using MailSenderWpf.Infrastructure.Services.Interfaces;

namespace MailSenderWpf.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var services = SimpleIoc.Default;

            services.Register<MainWindowViewModel>();
            services.Register<IRecipientsManager, RecipientsManager>();
            services.Register<IRecipientsStore, RecipientsStoreInMemory>();
            services.Register<ISendersStore, SendersStoreInMemory>();
            services.Register<IServersStore, ServersStoreInMemory>();
            services.Register<IMailsStore, MailsStoreInMemory>();
            services.Register<ISenderEditor, WindowSenderEditor>();
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
