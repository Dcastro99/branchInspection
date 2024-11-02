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
            //    //---------- Seed users if none exist ----------//
            //    if (!_dataContext.Users.Any())
            //    {
            //        var users = new List<User>
            //{
            //    new User
            //    {
            //        FirstName = "Mario",
            //        LastName = "Bros",
            //        Mi = "M", // Optional
            //        Email = "mario@bros.com",
            //        DefaultLocationId = "1",
            //        CompanyId = "GEN",
            //        EmployeeId = 2024,
            //        ActiveInd = "Y"
            //        // No need to set RoleId here since roles are seeded after
            //    },
            //    new User
            //    {
            //        FirstName = "Luigi",
            //        LastName = "Bros",
            //        Mi = "L", // Optional
            //        Email = "luigi@bros.com",
            //        DefaultLocationId = "1",
            //        CompanyId = "GEN",
            //        EmployeeId = 2025,
            //        ActiveInd = "Y"
            //    }
            //};

            //        _dataContext.Users.AddRange(users);
            //        _dataContext.SaveChanges();
            //    }

            //    // Now that users are created, you can fetch the UserId for Mario (UserId = 1)
            //    var createdByUserId = _dataContext.Users.FirstOrDefault(u => u.Email == "dcastro@gensco.com")?.UserId;

            //    //---------- Seed roles if none exist ----------//
            //    if (!_dataContext.Roles.Any() && createdByUserId != null)
            //    {
            //        var roles = new List<Role>
            //{
            //    new Role { RoleDescription = "Admin", CreatedByUserId = createdByUserId.Value, CreatedDate = DateTime.UtcNow, DateLastMaintained = DateTime.UtcNow, DeleteFlag = false },
            //    new Role { RoleDescription = "Teammember", CreatedByUserId = createdByUserId.Value, CreatedDate = DateTime.UtcNow, DateLastMaintained = DateTime.UtcNow, DeleteFlag = false },
            //    new Role { RoleDescription = "Ops", CreatedByUserId = createdByUserId.Value, CreatedDate = DateTime.UtcNow, DateLastMaintained = DateTime.UtcNow, DeleteFlag = false },
            //    new Role { RoleDescription = "Manager", CreatedByUserId = createdByUserId.Value, CreatedDate = DateTime.UtcNow, DateLastMaintained = DateTime.UtcNow, DeleteFlag = false }
            //};

            //        _dataContext.Roles.AddRange(roles);
            //        _dataContext.SaveChanges();
            //    }

            //    // Get the seeded role IDs for future use
            //    var adminRoleId = _dataContext.Roles.FirstOrDefault(r => r.RoleDescription == "Admin")?.RoleId;
            //    var userRoleId = _dataContext.Roles.FirstOrDefault(r => r.RoleDescription == "Teammember")?.RoleId;

            //    // You can now update the users with RoleIds if necessary
            //    var mario = _dataContext.Users.FirstOrDefault(u => u.Email == "mario@bros.com");
            //    if (mario != null && adminRoleId != null)
            //    {
            //        mario.RoleId = adminRoleId.Value;
            //    }

            //    var luigi = _dataContext.Users.FirstOrDefault(u => u.Email == "luigi@bros.com");
            //    if (luigi != null && userRoleId != null)
            //    {
            //        luigi.RoleId = userRoleId.Value;
            //    }

            //    _dataContext.SaveChanges();


            //---------- Seed branches items -----------//
            if (!_dataContext.Branches.Any())
            {
                var branches = BranchData.Branches.Select(ci => new Branch
                {
                    BranchName = ci.BranchName,
                    BranchNumber = ci.BranchNumber
                }).ToList();

                _dataContext.Branches.AddRange(branches);
                _dataContext.SaveChanges();
            }

            //---------- Seed categories -----------//
            if (!_dataContext.Categories.Any())
            {
                var categories = CategoryDBData.CategoryNames
                    .Select(name => new Category { CategoryName = name })
                    .ToList();

                _dataContext.Categories.AddRange(categories);
                _dataContext.SaveChanges();
            }
          
            ////---------- Seed checklist items -----------//
            //if (!_dataContext.ChecklistItems.Any())
            //{
            //    var checklistItems = ChecklistItemsData.ChecklistItems
            //        .Select(ci => new ChecklistItem
            //        {
            //            Name = ci.Name,
            //            CategoryId = ci.CategoryId,
            //            CheckedFlag = ci.CheckedFlag,
            //            NotApplicable = ci.NotApplicable,
            //            LoadCapacity = ci.LoadCapacity,
            //            DateCartridgeInstalled = ci.DateCartridgeInstalled,
            //            SafetyLastMeetingDate = ci.SafetyLastMeetingDate,
            //            StatePosterDatePosted = ci.StatePosterDatePosted,
            //            FireAlarmDateTested = ci.FireAlarmDateTested,
            //            SprinlerSystemDateTested = ci.SprinlerSystemDateTested,
            //            SecurityAlarmDateTested = ci.SecurityAlarmDateTested,
            //            DotInspectionDate = ci.DotInspectionDate


            //        })
            //        .ToList();

            //    _dataContext.ChecklistItems.AddRange(checklistItems);
            //    _dataContext.SaveChanges();
            //}

            //---------- Seed Branch Inspections -----------//
            //if (!_dataContext.BranchInspections.Any())
            //{
            //    var branchInspections = new List<BranchInspection>
            //    {
            //        new BranchInspection
            //        {

            //            BranchId = 1,
            //            ApprovedDate = DateTime.Now,
            //            CreatedDate = DateTime.Now,
            //            DateLastMaintained = DateTime.Now,
            //            SubmittedDate = DateTime.Now,
            //            CompanyId = "GEN",
            //            CreatedByUserId = 2,
            //            ApprovedByUserId = 1,
            //            DeleteFlag = "N",
            //            RevisedDate = DateTime.Now,



            //        }
            //    };

            //    _dataContext.BranchInspections.AddRange(branchInspections);
            //    _dataContext.SaveChanges();
            //}
        }
    }
}
