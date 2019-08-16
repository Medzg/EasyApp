using Autofac;
using Prism.Events;
using EasyApp.DataAccess;
using EasyApp.DataService.Repositories;
using EasyApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp.Startup
{
    class BootStrapper
    {
        public IContainer Bootstrap()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<EasyAppDBContext>().AsSelf();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<HomeViewModel>().AsSelf();

            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
        
            return builder.Build();
        }
    }
}
