using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MyMuesli.Model;
using MyMuesli.Service;
using MyMuesli.ViewModel;
using Unity;

namespace MyMuesli
{
    public class ViewModelLocator
    {
        private readonly UnityContainer container;
        public ViewModelLocator()
        {
            container = new UnityContainer();
            RegisterInstances();
           /* ServiceLocator.SetLocatorProvider(()=> SimpleIoc.Default)*/;
        }

        private void RegisterInstances()
        {
            container.RegisterType<IDatabaseService, DatabaseService>(new ContainerControlledLifetimeManager());
        }
        public void InitCustomer(ICustomerDetails selectedCustomer)
        {
            container.RegisterInstance<ICustomerDetails>(selectedCustomer);
        }
        internal static ViewModelLocator Instance => Application.Current.Resources["Locator"] as ViewModelLocator;

        public MainViewModel Main => container.Resolve<MainViewModel>();
        public CustomerSelectionViewModel Selection => container.Resolve<CustomerSelectionViewModel>();
        public OrderViewModel Order => container.Resolve<OrderViewModel>();
        public CerealMixerViewModel Cereal => container.Resolve<CerealMixerViewModel>();
        public MyCerealMixesViewModel MyCereal => container.Resolve<MyCerealMixesViewModel>();
        public CustomerDetailsViewModel Customer => container.Resolve<CustomerDetailsViewModel>();
    }
}
