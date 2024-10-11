using genscoSQLProject1.Data;
using genscoSQLProject1.Models;
using genscoSQLProject1.SeedData;


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
            //--------- Seed roles if none exist ----------//
            if (!_dataContext.Roles.Any())
            {
                var roles = new List<Role>
                {
                 new Role {  RoleDescription = "Admin" },
                 new Role {  RoleDescription = "Teammember" },
                 new Role {  RoleDescription = "Ops" },
                 new Role {  RoleDescription = "Manager" }

                };

                _dataContext.Roles.AddRange(roles);
                _dataContext.SaveChanges(); 
            }

            var adminRoleId = _dataContext.Roles.FirstOrDefault(r => r.RoleDescription == "Admin")?.RoleId;
            var userRoleId = _dataContext.Roles.FirstOrDefault(r => r.RoleDescription == "Teammember")?.RoleId;

            //---------- Seed users if none exist ----------//
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
                    RoleId = adminRoleId.Value,
                    DefaultLocationId = "1",
                    CompanyId = "GEN",
                    EmployeeId = 2024,
                    ActiveInd = "Y"
                 },
                 new User
                 {
                    FirstName = "Luigi",
                    LastName = "Bros",
                    Mi = "L", // Optional
                    Email = "luigi@bros.com",
                    RoleId = userRoleId.Value,
                    DefaultLocationId = "1",
                    CompanyId = "GEN",
                    EmployeeId = 2025,
                    ActiveInd = "Y"
                 }
                };

                _dataContext.Users.AddRange(users);
                _dataContext.SaveChanges();
            }

            //---------- Seed checklist items -----------//
            if (!_dataContext.Branches.Any())
            {
                var branches = BranchData.Branches
                    .Select(ci => new Branch

                    {
                        BranchName = ci.BranchName,
                        BranchNumber = ci.BranchNumber
                    })
                    .ToList();



                _dataContext.Branches.AddRange(branches);
                _dataContext.SaveChanges();
            }

            //---------- Seed categories -----------//
            if (!_dataContext.Categories.Any())
            {
                var categories = CategoryData.CategoryNames
                    .Select(name => new Category { CategoryName = name })
                    .ToList();

                _dataContext.Categories.AddRange(categories);
                _dataContext.SaveChanges();
            }

            //---------- Seed checklist items -----------//
            if (!_dataContext.ChecklistItems.Any())
            {
                var checklistItems = ChecklistItemsData.ChecklistItems
                    .Select(ci => new ChecklistItem
                    {
                        Name = ci.Name,
                        CategoryId = ci.CategoryId,
        
                    })
                    .ToList();

                _dataContext.ChecklistItems.AddRange(checklistItems);
                _dataContext.SaveChanges();
            }
           





        }


    }
}
