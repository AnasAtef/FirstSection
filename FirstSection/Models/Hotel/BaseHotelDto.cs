﻿using System.ComponentModel.DataAnnotations;

namespace FirstSection.Models.Hotel
{
    public class BaseHotelDto {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Address { get; set; }

        public double? Rating { get; set; }
        [Required]

        public int CountryId { get; set; }
    }
}