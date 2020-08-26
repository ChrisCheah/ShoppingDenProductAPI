using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDenProductAPI.Models
{
    public class Catalog
    {
        [Key]
        public long CatalogId { get; set; }
        public string CatalogName { get; set; }

        public ICollection<Product> ProductList { get; set; }

    }
}
