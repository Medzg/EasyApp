using EasyApp.DataService.Repositories;
using EasyApp.Event;
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
   public class LoginViewModel : ViewModelBase
    {
        private IUserRepository _dataRepository;
        private IEventAggregator _eventAggreator;

        public LoginViewModel(IUserRepository userRepository,IEventAggregator eventAggregator)
        {
            _dataRepository = userRepository;
            LoginCommand = new DelegateCommand(OnLoginExectute, OnLoginCanExecute);
            _eventAggreator = eventAggregator;
        }

        private bool OnLoginCanExecute()
        {
            return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password); 
        }

        private async void OnLoginExectute()
        {
            var data = await _dataRepository.CheckCredentials(Username, Password);

            if (data != null)
            {
                _eventAggreator.GetEvent<AfterLoginEvent>().Publish(data.Id);
            
      
            }
            else
            {
                MessageBox.Show("Incorrect username and passowrd");
            }
        }

        public ICommand LoginCommand { get; set; }

      
        private string _username;

        public string Username
        {
            get { return _username; }
            set {
                if( _username != value) { 
                _username = value;
                OnPropertyChanged();
                    ((DelegateCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }
        private string _password;
        

        public string Password
        {
            get { return _password; }
            set {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    ((DelegateCommand)LoginCommand).RaiseCanExecuteChanged();
                }
                }
        }



    }
}
