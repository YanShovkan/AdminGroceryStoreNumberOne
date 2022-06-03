using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class BasketViewModel
    {
        public string id { get; set; }
        [DisplayName("Дата")]
        public string date { get; set; }
        [DisplayName("Стоимость")]
        public decimal totalPrice { get; set; }
        [DisplayName("Пользователь")]
        public string userName { get; set; }
        [DisplayName("Место сборки")]
        public string adress { get; set; }
    }
}
