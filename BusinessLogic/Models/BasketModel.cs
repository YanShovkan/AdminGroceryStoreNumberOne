using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class BasketModel
    {
        public string id { get; set; }
        public long date { get; set; }
        public decimal totalPrice { get; set; }
        public string userId { get; set; }
        public string adress { get; set; }
    }
}
