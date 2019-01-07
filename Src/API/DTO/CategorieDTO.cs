using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public partial class CategorieDTO
    {
        public int IdCategorie { get; set; }
        public string Libelle { get; set; }
    }
}
