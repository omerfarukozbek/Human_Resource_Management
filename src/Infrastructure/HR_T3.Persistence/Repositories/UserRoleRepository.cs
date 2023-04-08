using HR_T3.Context.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_T3.Persistence.Repositories
{
    public class UserRoleRepository
    {

        private readonly AppDbContext _dbContext;
        public UserRoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> InsertRole(string PersonId, string RoleId)
        {
            var DeletedUserRole = _dbContext.UserRoles.FirstOrDefault(x => x.UserId == PersonId);

            if (DeletedUserRole != null)
            {

                _dbContext.UserRoles.Remove(DeletedUserRole);
                await _dbContext.SaveChangesAsync();
            }
            IdentityUserRole<string> userRole = new IdentityUserRole<string>()
            {
                RoleId = "employee",
                UserId = PersonId
            };

            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();



            return "OK";
        }
    }
}
