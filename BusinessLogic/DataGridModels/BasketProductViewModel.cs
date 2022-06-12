using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataGridModels
{
    public class BasketProductViewModel
    {
        public string id { get; set; }
        [DisplayName("Название")]
        public string productName { get; set; }
        [DisplayName("Количество")]
        public int count { get; set; }
        [DisplayName("Стоимость")]
        public decimal totalPrice { get; set; }
    }
}
