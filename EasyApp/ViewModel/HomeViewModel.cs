using EasyApp.DataService.Repositories;
using EasyApp.Event;
using EasyApp.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {

        
        private IUserRepository _userRespository;

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value;
                OnPropertyChanged();
            }
        }



        public HomeViewModel(IEventAggregator eventAggregator ,IUserRepository userRepository)
        {
            eventAggregator.GetEvent<AfterLoginEvent>().Subscribe(AfterLoginExecute);
            _userRespository = userRepository; 
        }

        private async void AfterLoginExecute(int id)
        {
            var data = await _userRespository.GetByIdAsync(id);
            if(data != null)
            {

                FullName = data.FirstName + " " + data.LastName; 
            }
            
        }
    }
}
