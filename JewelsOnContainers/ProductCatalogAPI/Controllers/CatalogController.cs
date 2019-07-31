using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.Domain;
using ProductCatalogAPI.ViewModels;

namespace ProductCatalogAPI.Controllers
{
    // get api/catalog/items?pageSize=10&pageIndex=2

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase

    {
        private readonly CatalogContext _context;
        private readonly CatalogContext _config;
        public CatalogController(CatalogContext context , CatalogContext config)
        {
            _context = context;
            _config = config;
            // inject 
        }
        // get api/catalog/items?pageSize=10&pageIndex=2
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
                [FromQuery] int pageSize = 6, // these paremeters are going to come from queryhow many items on page
                [FromQuery] int pageIndex = 0) // which page are you on
        {   
            var itemsCount = await _context.CatalogItems.LongCountAsync();//database is called catalog context, call catalogItems
            //get the actual items
            var items = await _context.CatalogItems // go back to datababase, call the table catalogItems
                        .OrderBy(c => c.Name) // sorted by name
                        .Skip(pageSize * pageIndex) // get the respected items; skip the first 6 items ; skip is by rows
                        .Take(pageSize) // take from position where I want to
                        .ToListAsync(); // make a list asynchronously
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModels<CatalogItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = itemsCount,
                Data = items
            };
            return Ok(items);

        }

        private List<CatalogItem> ChangePictureUrl(List<CatalogItem> items)
        {
            items.ForEach(
                c => c.PictureUrl = c.PictureUrl.Replace("", _config["ExternalCatalogBaseUrl"]));
            return items;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var items = await _context.CatalogTypes.ToListAsync();
            return Ok(items);
        }

        public async Task<IActionResult> CatalogBrands()
        {
            var items = await _context.CatalogBrands.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")] // route to get to to getItems byId
        public async Task<IActionResult> GetItemsById(int id) // user will pass id for which they will get data
        {
            if(id<=0)
            {
                return BadRequest("Incorrect ID !");
            }

            // get item for database
            var item = await _context.CatalogItems
                .SingleOrDefault(c => c.Id == id);//pick only  one item which matches ID

            if(item == null)
            {
                return NotFound("Did not find the item");
            }
        }

    }
}