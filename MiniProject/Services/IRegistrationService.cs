using MiniProject.Model;

namespace MiniProject.Services
{
    public interface IRegistrationService
    {
        Task<int> Registration(Registration r);

        Task<Registration> GetLogin(Registration r);
    }
}
