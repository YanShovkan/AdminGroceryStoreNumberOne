using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CardModel
    {
        public string id { get; set; }
        public string userId { get; set; }
        public decimal discount { get; set; }
    }
}
