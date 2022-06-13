using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class ReportMovementOfGoodsModel
    {
        public string productName { get; set; }
        public int startCount { get; set; }
        public int income { get; set; }
        public int spending { get; set; }
        public int endCount { get; set; }
    }
}
