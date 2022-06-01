using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class BasketProductModel
    {
        public string id { get; set; }
        public string basketId { get; set; }
        public string productId { get; set; }
        public int count { get; set; }
    }
}
