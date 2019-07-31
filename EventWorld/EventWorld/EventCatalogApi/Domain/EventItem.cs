using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime EventDate { get; set; }

        public int EventTypeId { get; set; } // event category
        public virtual EventType EventType { get; set; }
        
        public int EventCityId { get; set; }
        public virtual EventCity EventCity { get; set; }

    
    }
}
