using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;

namespace ProductCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();
            if(!context.CatalogBrands.Any()) //if i do not have records in the table, only then fill it with data
            {//inserting rows in table
                context.CatalogBrands.AddRange(GetPreConfiguredCatalogBrands());
                context.SaveChanges(); //to save it to database else data will be stored temporarily
            }
            if (!context.CatalogTypes.Any()) //if i do not have records in the table, only then fill it with data
            {
                context.CatalogTypes.AddRange(GetPreConfiguredCatalogTypes());
                context.SaveChanges(); //to save it to database else data will be stored temporarily
            }
            if (!context.CatalogItems.Any()) //if i do not have records in the table, only then fill it with data
            {
                context.CatalogItems.AddRange(GetPreConfiguredCatalogItems());
                context.SaveChanges(); //to save it to database else data will be stored temporarily
            }

        }

        private static IEnumerable<CatalogItem> GetPreConfiguredCatalogItems()
        {
            throw new NotImplementedException();
        }

        private static IEnumerable <CatalogType> GetPreConfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
            new CatalogType(){ Type="Engagement Ring"},
            new CatalogType() { Type = "Wedding Ring" },
            new CatalogType() { Type = "Fashion Ring" },
            };

        }

        private static IEnumerable<CatalogBrand> GetPreConfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
            new CatalogBrand(){ Brand="Tiffany & Co."},
            new CatalogBrand() { Brand = "DeBeers" },
            new CatalogBrand() { Brand = "Graff" },
            };
        }

     }
   
}
