using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.WA1.Api.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public int Stock { get; set; }
        public int CategoriId { get; set; }
        public virtual Category Category { get; set; }
    }
}
