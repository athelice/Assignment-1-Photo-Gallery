using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Data;
using EventCatalogApi.Domain;
using EventCatalogApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;

        public EventCatalogController(EventContext context,
           IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //GET api/catalog/items?pageSize=10&pageIndex=2
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageSize = 4,
            [FromQuery] int pageIndex = 0)
        {
            //get total count
            var itemsCount = await _context.EventItems.LongCountAsync();

            var items = await _context.EventItems
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);

        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(
                c => c.PictureUrl =
                c.PictureUrl
                .Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogBaseUrl"]));
            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCities()
        {
            var items = await _context.EventCities.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect Id");
            }
            var item = await _context.EventItems
                .SingleOrDefaultAsync(c => c.Id == id);
            if (item == null)
            {
                return NotFound("Event Item not found");

            }
            item.PictureUrl = item.PictureUrl
                .Replace("http://externalcatalogbaseurltobereplaced"
                , _config["ExternalCatalogBaseUrl"]);
            return Ok(item);
        }
    }
}