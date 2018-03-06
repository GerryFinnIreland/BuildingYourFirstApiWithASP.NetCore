using System.Collections.Generic;
using Exercise.API.Models;

namespace Exercise.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore(); //new to c# 6 auto property initalizer syntax, allows assignment of propertiesd directly in there declaration, property is immutable, unchanging over time

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            //init data
            Cities = new List<CityDto>() {
                new CityDto()
                {
                    Id = 1,
                    Name = "Dublin",
                    Description = "Big Spire",
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "spire",
                            Description = "Pinty thing"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "captain americas",
                            Description = "tasty milkshakes"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Sligo",
                    Description = "The Belfry",
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "river",
                            Description = "Faravogue"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "pubs",
                            Description = "many"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Galway",
                    Description = "Rain",
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "salt hill",
                            Description = "salty"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "water world",
                            Description = "watery"
                        }
                    }
                }
            };
        }
    }
}
