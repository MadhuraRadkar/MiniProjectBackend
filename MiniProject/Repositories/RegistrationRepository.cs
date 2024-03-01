using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext db;

        public RegistrationRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Registration> GetLogin(Registration r)
        {
          
            Registration result = await db.registers.Where(x => x.Email == r.Email && x.Password == r.Password).FirstOrDefaultAsync();
           
            return result;
        }

        public async Task<int> Registration(Registration r)
        {
            r.RoleId = 2;
            db.registers.Add(r);
            int result = await db.SaveChangesAsync();
            return result;
        }
    }
}
