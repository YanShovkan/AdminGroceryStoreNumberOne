using System.ComponentModel;

namespace BusinessLogic.Models
{
    public class ProductModel
    {
        public string id { get; set; }
        [DisplayName("Название")]
        public string name { get; set; }
        [DisplayName("Стоимость")]
        public decimal price { get; set; }
        [DisplayName("Скидка")]
        public decimal discount { get; set; }
    }
}
