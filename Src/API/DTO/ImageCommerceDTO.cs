using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public class ImageCommerceDTO
    {
        [Required]
        public int IdImageCommerce { get; set; }
        [Required]
        public string Url { get; set; }
        public int? IdCommerce { get; set; }
    }
}