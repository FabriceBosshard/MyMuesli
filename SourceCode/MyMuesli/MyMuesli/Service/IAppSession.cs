using MyMuesli.Model;

namespace MyMuesli.Service
{
    public interface IAppSession
    {
        CustomerDetails Customer { get; set; }
        Cereal EditableCereal { get; set; }
    }
}