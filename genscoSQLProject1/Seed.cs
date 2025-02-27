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

           
        }
    }
}
