using MyMuesli.Model;

namespace MyMuesli.Service
{
    public interface IAppSession
    {
        CustomerDetails Customer { get; set; }
    }
}