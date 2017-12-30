using PhoneNumbers;

namespace BusinessLayer
{
    public interface IContact
    {
        int ContactId { get; set; }
        string EmailId { get; set; }
        string ContactNumber { get; set; }
        string StreetName { get; set; }
        string City { get; set; }
        string Taluka { get; set; }
        string District { get; set; }
        string Pincode { get; set; }
        string State { get; set; }
        string Country { get; set; }
    }
}
