namespace MyMuesli.Model
{
    public interface ICustomerDetails
    {
        string Name { get; set; }
        string City { get; set; }
        string Zip { get; set; }
        string Country { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
    }
}