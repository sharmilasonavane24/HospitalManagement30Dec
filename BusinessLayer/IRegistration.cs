

namespace BusinessLayer
{

    public interface IRegistration
    {
        int UserId { get; set; }

        string Email { get; set; }

        string Password { get; set; }

        string PasswordSalt { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        UserTypes UserType { get; set; }

        System.DateTime CreatedDate { get; set; }

        bool IsActive { get; set; }

        string ContactNumber { get; set; }

        //public string IPAddress { get; set; }
    }
}