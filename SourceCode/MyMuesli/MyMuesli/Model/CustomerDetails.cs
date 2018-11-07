using MyMuesli.ViewModel;

namespace MyMuesli.Model
{
    public class CustomerDetails
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public Country Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}