using EasyApp.Model;
using EasyApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp.Wrapper
{
 public   class UserWrapper : ViewModelBase
    {
        public UserWrapper(User user)
        {
            User = user;
        }

        public User User { get; set; }

        public int Id { get { return User.Id; } }

      
        public string Username { get { return User.Username; } set {
                if(User.Username != value)
                {
                    User.Username = value;
                    OnPropertyChanged();
                }
                ; } }

        
        public string password {
            get { return User.password; }
            set
            {
                if (User.password != value)
                {
                    User.password = value;
                    OnPropertyChanged();
                }
;
            }
        }
     
        public string FirstName {
            get { return User.FirstName; }
            set
            {
                if (User.FirstName != value)
                {
                    User.FirstName = value;
                    OnPropertyChanged();
                }
;
            }
        }
  
        public string LastName {
            get { return User.LastName; }
            set
            {
                if (User.LastName != value)
                {
                    User.LastName= value;
                    OnPropertyChanged();
                }
;
            }
        }

      
     
        public string Email { get {
                return User.Email;

            } set {
                if(User.Email != value)
                {
                    User.Email = value;
                    OnPropertyChanged();
                }

            } }
    }
}
