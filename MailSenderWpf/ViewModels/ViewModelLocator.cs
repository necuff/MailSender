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
            services.Register<RecipientsManager>();
            services.Register<RecipientsStoreInMemory>();
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
