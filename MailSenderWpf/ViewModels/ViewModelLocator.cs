using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib.Data.EF;
using MailSenderLib.Services;
using MailSenderLib.Services.EF;
using MailSenderLib.Services.Interfaces;
using MailSenderWpf.Infrastructure.Services;
using MailSenderWpf.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            //services.Register<IRecipientsStore, RecipientsStoreInMemory>();
            services.Register<IRecipientsStore, RecipientsStoreEF>();
            services.Register<ISendersStore, SendersStoreInMemory>();
            services.Register<IServersStore, ServersStoreInMemory>();
            services.Register<IMailsStore, MailsStoreInMemory>();
            services.Register<ISenderEditor, WindowSenderEditor>();

            services.Register<MailSenderDB>();
            services.Register(() => new DbContextOptionsBuilder<MailSenderDB>().UseSqlServer(App.Configuration.GetConnectionString("DefaultConnection")).Options);

        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
