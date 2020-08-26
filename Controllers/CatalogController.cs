using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingDenProductAPI.Models;
using ShoppingDenProductAPI.Repositories;

namespace ShoppingDenProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private readonly ICatalogRepository _catalogRepository;


        public CatalogController(ICatalogRepository catalogRepository)
        {
            this._catalogRepository = catalogRepository;
        }



        // GET: api/Catalog
        [HttpGet]
        public IActionResult Get()
        {
            var catalogs= this._catalogRepository.GetAllCatalogs();
            return new OkObjectResult(catalogs);
        }

        // GET: api/Catalog/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var catalog=this._catalogRepository.GetCatalogById(id);
            return new OkObjectResult(catalog);
        }

        // POST: api/Catalog
        [HttpPost]
        public IActionResult Post([FromBody] Catalog catalog)
        {
            using (var scope = new TransactionScope())
            {
                _catalogRepository.AddCatalog(catalog);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = catalog.CatalogId }, catalog);
            }
        }

        // PUT: api/Catalog/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Catalog catalog)
        {
            if (catalog != null)
            {
                using (var scope = new TransactionScope())
                {
                    _catalogRepository.UpdateCatalogById(catalog);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _catalogRepository.DeleteCatalogById(id);
            return new OkResult();
        }
    }
}
