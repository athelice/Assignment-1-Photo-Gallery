using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Domain;

namespace EventCatalogApi.Data
{
    public class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            if(!context.EventTypes.Any())
            {
                context.EventTypes
                    .AddRange(GetPreconfiguredEventTypes());
                context.SaveChanges();

            }

            if (!context.EventCities.Any())
            {
                context.EventCities
                    .AddRange(GetPreconfiguredEventCities());
                context.SaveChanges();

            }
            if (!context.EventItems.Any())
            {
                context.EventItems
                    .AddRange(GetPreconfiguredEventItems());
                context.SaveChanges();

            }

          

        }

        private static IEnumerable<EventCity> GetPreconfiguredEventCities()
        {
            return new List<EventCity>()
            {
                new EventCity(){City="Redmond"},
                new EventCity(){City="Seattle"},
                new EventCity(){City="Kirkland"},
                new EventCity(){City="Sammamish" },
                new EventCity(){City="Bellevue" }
            };
        }

        private static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem()
             {
                EventTypeId = 3,
                EventCityId = 1,
                Name = "Fit Fest",
                Description = "An event combining a light workout, followed by healthy hosted appetizers, thirst-quenching drinks, and of course networking with other active young fitness enthusiats!",
                Price = 10,
                Address = " Redmond Town Centre, 710 North 34th Street",
                EventDate = new DateTime(2019, 7, 18, 17, 0, 0),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1"
            },

                //Fitness Sammamish
                new EventItem()
                {
                    EventTypeId = 3,
                    EventCityId = 4,
                    Name = " Subaru Kids Obstacle Challenge ",
                    Description = " Subaru Kids Obstacle Challenge is an adventure and obstacle course race series for kids!",
                    Price = 20,
                    Address = "Lake Sammamish State Park 2000 NW Sammamish Rd.",
                    EventDate = new DateTime(2019, 8, 17, 09, 0, 0),
                    PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3"
                },

                //Food festival Seattle
                new EventItem()
                {
                    EventTypeId = 1,
                    EventCityId = 2,
                    Name = "The English Beat at Foodstock",
                    Description =" Come enjoy the music of three bands, a food truck rodeo, snow-cones, and activities for the entire family",
                    Price = 15,
                    Address = " Meridian Park 4649 Sunnyside Avenue North Seattle, WA 98103",
                    EventDate = new DateTime(2019, 9, 08, 13, 0, 0),
                    PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4"
                },

                //Food Festival Seattle
                new EventItem()
                {
                    EventTypeId = 1,
                    EventCityId = 2,
                    Name = " Grilled Cheese Grand Prix 2019",
                    Description = "Sink your teeth into Seattle's favorite emerging food festivals that celebrates bread, cheese and everything festival",
                    Price = 15,
                    Address = "South Lake Union Discovery Center 101 Westlake Avenue North Seattle",
                    EventDate = new DateTime(2019, 9, 14, 12, 0, 0),
                    PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5"
                },

                //Networking & Job Fair  Bellevue 
                new EventItem()
                {
                    EventTypeId = 4,
                    EventCityId = 5,
                    Name = " Seattle Job Fair & Career Fair",
                    Description = "Meet, sit down and interview with Nationally Known employers at The Seattle Career Fair",
                    Price = 0,
                    Address = "100 112th Ave NE Bellevue,Washington 98004",
                    EventDate = new DateTime(2019, 8, 06, 09, 0, 0),
                    PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8"
                },

                //Networking Seattle
            new EventItem()
            {
                EventTypeId = 4,
                EventCityId = 2,
                Name = "WhatDoIWantWednesday",
                Description = "Women+Thrive’s purpose is to provide a community of resources, guidance, and support for women at all stages of their careers ",
                Address = " The Ninety 406 Occidental Avenue South Seattle",
                EventDate = new DateTime(2019, 7, 31, 09, 0, 0),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9"
            },
            //Job Fair  / Networking Seattle
            new EventItem()
            {
                EventTypeId = 4,
                EventCityId = 2,
                Name = " Job Fair Seattle",
                Description = "Job Fair Pro has teamed up with Best Hire Career Fairs to bring you the best Job Fairs",
                Price = 25,
                Address = "211 Dexter Avenue North Seattle, WA 98109",
                EventDate = new DateTime(2019, 08, 12, 09, 0, 0),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10"
            },
              new EventItem()
            {
                EventTypeId = 1,
                EventCityId = 3,
                Name = "1000 Lights Water Lantern Festival",
                Description = "Come experience the beauty as thousands of lanterns illuminate the water at the 1000 Lights Water Lantern Festival in Kirkland, WA.",
                Price = 25,
                Address = "Juanita Beach Park 9703 Northeast Juanita Drive",
                EventDate = new DateTime(2019, 08, 10, 19, 0, 0),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12"
            },

                new EventItem()
            {
                EventTypeId = 5,
                EventCityId = 2,
                Name = "Seaferry Boat Cruise",
                Description = "Come aboard party pirates, let’s do this. ",
                Price = 25,
                Address = "Museum of History & Industry (MOHAI) 860 Terry Avenue North Seattle, WA 98109 ",
                EventDate = new DateTime(2019, 08, 03, 17, 0, 0),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13"
            },

            new EventItem()
            {
                EventTypeId = 5,
                EventCityId = 2,
                Name = "Boat Party Europa",
                Description = "Enjoy beautiful sightseeing around Lake Union and Lake Washington to the live music of New Age Flamenco on the upper deck. ",
                Price = 65,
                Address = "The Islander Yacht 1611 Fairview Ave E Seattle",
                EventDate = new DateTime(2019, 08, 25, 17, 0, 0),
                PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"
            }
        
        };
        }


        private static IEnumerable<EventType> GetPreconfiguredEventTypes()
        {
            return new List<EventType>()
            {
                new EventType(){Type="Food Festival"},
                new EventType(){Type="Music"},
                new EventType(){Type="Sport & Fitness"},
                new EventType(){Type="Networking" },
                new EventType(){Type="Party" },
                new EventType(){Type="Community Event" }
            };
        }
    }
}
