using Autofac;
using Mailler.UI.Data;
using Mailler.UI.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailler.UI.Bootstraper
{
    public class Bootstrapper 
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<ContactDetailViewModel>().As<IContactDetailViewModel>();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<LookUpContactDataService>().AsImplementedInterfaces();
            return builder.Build();
        }
    }
}
