using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class ShopModel
    {
        public string id { get; set; }
        [DisplayName("Широта")]
        public double latitude { get; set; }
        [DisplayName("Долгота")]
        public double longitude { get; set; }
        [DisplayName("Адрес")]
        public string adress { get; set; }
    }
}
