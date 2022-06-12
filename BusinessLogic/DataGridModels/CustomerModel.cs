using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataGridModels
{
    public class CustomerModel
    {
        public string id { get; set; }
        [DisplayName("Покупатель")]
        public string userLogin { get; set; }
        [DisplayName("Скидка")]
        public string cardDiscount { get; set; }
    }
}
