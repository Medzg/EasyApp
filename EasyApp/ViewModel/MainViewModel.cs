using EasyApp.Event;
using EasyApp.View;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
                    OnPropertyChanged();
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

        public object _SingupViewModel { get; set; }






        public MainViewModel(LoginViewModel loginViewModel, IEventAggregator eventAggregator, HomeViewModel homeViewModel,SingupViewModel singupViewModel)
        {

            HomeViewModel = homeViewModel; 
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterLoginEvent>().Subscribe(AfterLoginExecute);
            _eventAggregator.GetEvent<AfterSingupEvent>().Subscribe(AfterSingupExecute);
            _LoginViewModel = loginViewModel; 
            DisplayViewModel = _LoginViewModel;
            _SingupViewModel = singupViewModel;
          
       
            
        }


        

        private void AfterSingupExecute(int? id)
        {
            if (id.HasValue)
            {
                if(id.Value!= -1) { 
                _eventAggregator.GetEvent<AfterLoginEvent>().Publish(id.Value);
                }
                else
                {
                    ((SingupViewModel)_SingupViewModel).Setup();
                    DisplayViewModel = _SingupViewModel;
                }
            }
            else
            {
                DisplayViewModel = _LoginViewModel;
            }
        }

        private  void AfterLoginExecute(int obj)
        {
            DisplayViewModel = HomeViewModel;

            _eventAggregator.GetEvent<AfterLoginEvent>().Unsubscribe((int x)=> { });
            
           
        }

        
    }
}
