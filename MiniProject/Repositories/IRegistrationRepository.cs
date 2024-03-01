using Microsoft.Win32;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public interface IRegistrationRepository
    {
        Task<int> Registration(Registration r);

        Task<Registration> GetLogin(Registration r);
    }
}
