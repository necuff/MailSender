using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.MVVM;

namespace WpfTest.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Наше новое окно!";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
            /*
            set
            {
                if (Equals(_Title, value)) return;                 
                _Title = value;
                OnPropertyChanged("title");
                OnPropertyChanged();
                
            }
            */
        }
    }
}
