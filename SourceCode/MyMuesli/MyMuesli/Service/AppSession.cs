using MyMuesli.Model;

namespace MyMuesli.Service
{
    public class AppSession : IAppSession
    {
        public AppSession(CustomerDetails selectedCustomer)
        {
            Customer = selectedCustomer;
        }

        public CustomerDetails Customer { get; set; }
        public Cereal EditableCereal { get; set; }
    }
}