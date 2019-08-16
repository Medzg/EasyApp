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

        private object _displayViewModel ;
        private IEventAggregator _eventAggregator;

        public object DisplayViewModel
        {
            get { return _displayViewModel; }
            set { _displayViewModel = value;
                OnPropertyChanged();
            }
        }

        private object _homeViewModel;

        public object HomeViewModel
        {
            get { return _homeViewModel; }
            set { _homeViewModel = value;
                OnPropertyChanged();
            }
        }






        public MainViewModel(LoginViewModel loginViewModel,IEventAggregator eventAggregator , HomeViewModel homeViewModel)
        {

            HomeViewModel = homeViewModel; 
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterLoginEvent>().Subscribe(AfterLoginExecute);

            DisplayViewModel = loginViewModel;
       
            
        }

        private  void AfterLoginExecute(int obj)
        {
            DisplayViewModel = HomeViewModel;

            _eventAggregator.GetEvent<AfterLoginEvent>().Unsubscribe((int x)=> { });
            
           
        }

        
    }
}
