using System.Collections.Generic;


namespace Exercise.API.Models
{
    public class CityDto
    {
        //dtos are different to entity, that could contain calculated fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public int NumberOfPointsOfInterest => PointsOfInterest.Count;

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
