

namespace BusinessLayer
{

    public interface IPerson
    {
        int PersonId { get; set; }
        string Firstname { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        Gender Gender { get; set; }
        object BirthDate { get; set; }
        decimal?  Age { get; set; }
        int? Height { get; set; }
        string RegisterDate { get; set; }
        string AdharCardNumber { get; set; }
        string Profession { get; set; }
        PersonTypes PersonType { get; set; }
        
    }

}
