using EasyApp.DataService.Repositories;
using EasyApp.Event;
using EasyApp.Model;
using EasyApp.Wrapper;
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
   public class SingupViewModel :ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private IUserRepository _userRepository;
 
        public SingupViewModel(IEventAggregator eventAggregator , IUserRepository userRepository)
        {

            _eventAggregator = eventAggregator;
            _userRepository = userRepository;
            SingupCommand = new DelegateCommand(OnSingupExecute, onSingupCanExecute);
            BackHomeCommand = new DelegateCommand(OnBackHomeExecute);


        }
        public void Setup()
        {
            this.User = new UserWrapper(new User());
        }

        private void OnBackHomeExecute()
        {
            _eventAggregator.GetEvent<AfterSingupEvent>().Publish(null);
        }

        private bool onSingupCanExecute()
        {
            return true;
        }

        private async void OnSingupExecute()
        {
            var data = await _userRepository.CheckByUsername(User.Username);
            if(data != null)
            {
                MessageBox.Show("This user " + User.Username + " is already exsiting");
            }
            else
            {
                _userRepository.Add(User.User);
               await _userRepository.SaveAsync();
                _eventAggregator.GetEvent<AfterSingupEvent>().Publish(User.Id);
            }
         
        }

        public ICommand BackHomeCommand { get; set; }

        private UserWrapper _user;

        public UserWrapper User
        {
            get { return _user; }
            set {
                if (_user != value) {;
                    _user = value;
                    OnPropertyChanged();
                  
                }
                    
            }
        }

        public ICommand SingupCommand { get; set; }



    }
}
