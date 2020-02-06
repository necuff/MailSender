using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;

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
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
