using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.ViewModels
{
    public class PaginatedItemsViewModels<TEntity> // what items will go on the painated items
        where TEntity : class // reference types ; cannot create an instance with value types only reference types
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
