using AspNetCore.WA1.Api.Models.Data;
using AspNetCore.WA1.Api.Models.Entities;
using AspNetCore.WA1.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.WA1.Api.Models.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CoreWA1DbContext context) : base(context)
        {

        }
    }
}
