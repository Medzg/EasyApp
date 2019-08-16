using EasyApp.Event;
using EasyApp.View;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private object _LoginViewModel;

        public object LoginViewModel
        {
            get { return _LoginViewModel; }
            set
            {
                if (value != _LoginViewModel)
                {
                    _LoginViewModel = value;
                    OnPropertyChanged(); // The property changed method call
                }
            }
        }

        private FrameworkElement _displayViewModel ;
        private IEventAggregator _eventAggregator;

        public FrameworkElement DisplayViewModel
        {
            get { return _displayViewModel; }
            set { _displayViewModel = value;
                OnPropertyChanged();
            }
        }




        public MainViewModel(LoginViewModel loginViewModel,IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterLoginEvent>().Subscribe(AfterLoginExecute);

            DisplayViewModel = new LoginView();
            DisplayViewModel.DataContext = loginViewModel;
            
        }

        private  void AfterLoginExecute(int obj)
        {
            MessageBox.Show("PLEASE");
            
           
        }
    }
}
