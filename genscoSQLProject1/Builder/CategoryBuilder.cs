using genscoSQLProject1.Models;

namespace genscoSQLProject1.Builder
{
    public class CategoryBuilder
    {
        private readonly Category _category;

        public CategoryBuilder(string categoryName)
        {
            _category = new Category
            {
                CategoryName = categoryName,
              
            };
        }

        

        public Category Build()
        {
            return _category;
        }
    }
}
