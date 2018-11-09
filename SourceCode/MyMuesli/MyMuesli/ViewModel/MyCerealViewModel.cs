using GalaSoft.MvvmLight;
using MyMuesli.Model;

namespace MyMuesli.ViewModel
{
    public class MyCerealViewModel : ViewModelBase
    {
        public readonly Cereal Cereal;

        public MyCerealViewModel(Cereal c)
        {
            Cereal = c;
        }
        public string Name => Cereal.Name;
        public string Price => "CHF " + Cereal.Price;
        public string CreatedOn => Cereal.CreatedOn.ToString("dd.MM.yyyy");
    }
}