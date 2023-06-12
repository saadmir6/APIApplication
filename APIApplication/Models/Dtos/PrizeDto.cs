using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Models.Dtos
{
    public class PrizeDto
    {
        
        public PrizeDto(Prize prize)
        {
            Id = prize.Id;
            Category = prize.Category;
            Year = prize.Year;
            Laureates = prize.Laureates.Select(laureate => new LaureateDto(laureate)
            {
                Id = laureate.Id,
                Firstname = laureate.Firstname,
                Lastname = laureate.Lastname,
                CountryOfBirth = laureate.CountryOfBirth,
                Gender = laureate.Gender,
            }) as List<LaureateDto>;
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }

        public List<LaureateDto> Laureates { get; set; }
    }
}