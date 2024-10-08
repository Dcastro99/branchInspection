using genscoSQLProject1.Data;
using genscoSQLProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace genscoSQLProject1
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            _dataContext = context;
        }

        public void SeedDataContext()
        {
            // Seed roles if none exist
            if (!_dataContext.Roles.Any())
            {
                var roles = new List<Role>
                {
                 new Role {  RoleDescription = "Admin" },
                 new Role {  RoleDescription = "User" },
                 new Role {  RoleDescription = "Ops" }
                };

                _dataContext.Roles.AddRange(roles);
                _dataContext.SaveChanges(); // Ensure roles are saved first
            }

            var adminRoleId = _dataContext.Roles.FirstOrDefault(r => r.RoleDescription == "Admin")?.RoleId;
            var userRoleId = _dataContext.Roles.FirstOrDefault(r => r.RoleDescription == "User")?.RoleId;

            // Seed users if none exist
            if (!_dataContext.Users.Any())
            {
                var users = new List<User>
                {
                 new User
                 {
                    FirstName = "Mario",
                    LastName = "Bros",
                    Mi = "M", // Optional
                    Email = "mario@bros.com",
                    RoleId = adminRoleId.Value 
                 },
                 new User
                 {
                    FirstName = "Luigi",
                    LastName = "Bros",
                    Mi = "L", // Optional
                    Email = "luigi@bros.com",
                    RoleId = adminRoleId.Value 
                 }
                };

                _dataContext.Users.AddRange(users);
                _dataContext.SaveChanges(); // Save users after ensuring roles exist
            }

            if(!_dataContext.Branches.Any())
            {
                var branches = new List<Branch>
                {
                    new Branch
                    {
                        BranchName = "Tacoma",
                        BranchNumber = "1"
                    },
                    new Branch
                    {
                        BranchName = "Vancouver",
                        BranchNumber = "21"
                    }
                };
                _dataContext.Branches.AddRange(branches); 
                _dataContext.SaveChanges();
            }
        }


    }
}
