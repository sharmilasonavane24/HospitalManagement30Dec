

namespace BusinessLayer
{
    interface IMembershipService
    {
        string check_login(string userid, string password);
        string register(IRegistration registration);
    }
}
