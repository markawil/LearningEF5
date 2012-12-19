using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain;
using LearningEF5.DataLayer;

namespace WpfApplication1
{
   public class CastleBootstrapper : Bootstrapper<MainViewModel>
   {
      private IWindsorContainer _container;

      protected override void Configure()
      {
         _container = new WindsorContainer();

         // register components here
         _container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>());
         _container.Register(
            Component.For<IEventAggregator>().ImplementedBy<EventAggregator>().LifeStyle.Is(LifestyleType.Singleton));
//         _container.Register(Component.For<IRepository<Person>>().ImplementedBy<Repository<Person>>());
//         _container.Register(Component.For<IRepository<Session>>().ImplementedBy<Repository<Session>>());
//         _container.Register(Component.For<IRepository<Workshop>>().ImplementedBy<Repository<Workshop>>());
         
         _container.AddFacility<TypedFactoryFacility>();
         _container.Register(AllTypes.FromAssembly(typeof(MainViewModel).Assembly)
            .Where(x => x.Name.EndsWith("ViewModel") || x.Name.EndsWith("View"))
            .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
      }

      // needed if views and viewmodels are in a seperate assembly
      protected override IEnumerable<Assembly> SelectAssemblies()
      {
         return new[]
                   {
                      Assembly.GetExecutingAssembly(),
                      typeof(MainViewModel).Assembly
                   };
      }

      protected override object GetInstance(Type service, string key)
      {
         return string.IsNullOrWhiteSpace(key)
         ? _container.Resolve(service)
         : _container.Resolve(key, service);
      }

      protected override IEnumerable<object> GetAllInstances(Type service)
      {
         return (IEnumerable<object>)_container.ResolveAll(service);
      }

      protected override void BuildUp(object instance)
      {
         Extensions.ForEach(instance.GetType().GetProperties()
                     .Where(property => property.CanWrite && property.PropertyType.IsPublic)
                     .Where(property => _container.Kernel.HasComponent(property.PropertyType)),
                     property => property.SetValue(instance, _container.Resolve(property.PropertyType), null));
      }
   }
}