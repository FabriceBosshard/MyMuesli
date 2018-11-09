using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.ViewModel;
using Unity;

namespace MyMuesli
{
    public class ViewModelLocator
    {
        public readonly UnityContainer Container;
        public ViewModelLocator()
        {
            Container = new UnityContainer();
            RegisterInstances();
        }

        private void RegisterInstances()
        {
            Container.RegisterType<IDatabaseService, DatabaseService>(new ContainerControlledLifetimeManager());
        }
        public void InitCustomer(CustomerDetails selectedCustomer)
        {
            var session = new AppSession(selectedCustomer);
            Container.RegisterInstance<IAppSession>(session);
        }
        internal static ViewModelLocator Instance => Application.Current.Resources["ViewModelLocator"] as ViewModelLocator;
        public MainViewModel Main => Container.Resolve<MainViewModel>();
        public OrderViewModel Order => Container.Resolve<OrderViewModel>();
        public CerealMixerViewModel Cereal => Container.Resolve<CerealMixerViewModel>();
        public MyCerealMixesViewModel MyCereal => Container.Resolve<MyCerealMixesViewModel>();
        public CustomerDetailsViewModel Customer => Container.Resolve<CustomerDetailsViewModel>();
    }
}
