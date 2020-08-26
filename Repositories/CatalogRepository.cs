using Microsoft.EntityFrameworkCore;
using ShoppingDenProductAPI.Contexts;
using ShoppingDenProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDenProductAPI.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogContext _dbContext;

        public CatalogRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCatalog(Catalog catalog)
        {
            _dbContext.Add(catalog);
            Save();
        }

        public void DeleteCatalogById(long catalogId)
        {
            var catalog = _dbContext.Catalogs.Find(catalogId);
            _dbContext.Catalogs.Remove(catalog);
            Save();
        }



        public Catalog GetCatalogById(long catalogId)
        {
            return _dbContext.Catalogs.Find(catalogId);
        }


        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return _dbContext.Catalogs.ToList();
        }



        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCatalogById(Catalog catalog)
        {
            _dbContext.Entry(catalog).State = EntityState.Modified;
            Save();
        }
    }
}
