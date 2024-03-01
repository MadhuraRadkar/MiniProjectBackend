using MiniProject.Model;
using MiniProject.Repositories;

namespace MiniProject.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository repo;
        public RegistrationService(IRegistrationRepository repo)
        {
            this.repo = repo;
        }
        public async Task<Registration> GetLogin(Registration r)
        {
            return await repo.GetLogin(r);
        }

        public async Task<int> Registration(Registration r)
        {
            return await repo.Registration(r);
        }
    }
}
