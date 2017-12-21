using Autofac;
using Mailler.DataAccess;
using Mailler.UI.Data;
using Mailler.UI.Data.LookUps;
using Mailler.UI.Data.Repositories;
using Mailler.UI.View.Services;
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
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<ContactOrganizerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MessageDialogServices>().As<IMessageDialogServices>();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

            builder.RegisterType<LookUpContactDataService>().AsImplementedInterfaces();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();                                   
            builder.RegisterType<ContactDetailViewModel>().As<IContactDetailViewModel>();
            
            return builder.Build();
        }
    }
}
