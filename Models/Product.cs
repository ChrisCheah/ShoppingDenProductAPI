using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDenProductAPI.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }

        public string Name { get; set; }
        public DateTime DOP { get; set; }
        public long ActualCost { get; set; }
        public long Price { get; set; }
        public long AvailableQty { get; set; }

        public long BufferLevel { get; set; }

        [ForeignKey("Catalog")]
        public long CatalogRefId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
