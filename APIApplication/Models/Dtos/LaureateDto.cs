using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIApplication.Models.Dtos
{
    public class LaureateDto
    {
        

        public LaureateDto(Laureates laureates)
        {
            Id = laureates.Id;
            Firstname = laureates.Firstname;
            Lastname = laureates.Lastname;
            CountryOfBirth = laureates.CountryOfBirth;
            Gender = laureates.Gender;
            Prizes = laureates.Prizes.Select(prizes => new PrizeDto(prizes)
            {
                Id=prizes.Id,
                Category = prizes.Category,
                Year = prizes.Year
            }) as List<PrizeDto>;
        }


        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string CountryOfBirth { get; set; }

        public string Gender { get; set; }

        public List<PrizeDto> Prizes { get; set; }

    }
}