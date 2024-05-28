using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyBaneTest.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RallyDbContext _rallyDbContext;

        public CategoryRepository(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public IEnumerable<Category> AllCategories => 
            _rallyDbContext.Categories.OrderBy(c => c.Name);
            
    }

}