using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public partial class CategorieDTO
    {
        public CategorieDTO()
        {
            Commerce = new HashSet<CommerceDTO>();
        }

        public int IdCategorie { get; set; }
        public string Libelle { get; set; }

        public ICollection<CommerceDTO> Commerce { get; set; }
    }
}
