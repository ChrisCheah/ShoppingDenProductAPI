using ShoppingDenProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDenProductAPI.Repositories
{
    public interface ICatalogRepository
    {
        void AddCatalog(Catalog catalog);
        IEnumerable<Catalog> GetAllCatalogs();

        Catalog GetCatalogById(long catalogId);

        void DeleteCatalogById(long catalogId);
        void UpdateCatalogById(Catalog catalog);

    }
}
