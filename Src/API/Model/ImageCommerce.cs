using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class ImageCommerce
    {
        public int IdImageCommerce { get; set; }
        public string Url { get; set; }
        public int? IdCommerce { get; set; }

        public Commerce IdCommerceNavigation { get; set; }

        public ImageCommerce(){}

        public ImageCommerce(String url, int idCommerce){
            this.Url = url;
            this.IdCommerce = idCommerce;
        }
    }
}
