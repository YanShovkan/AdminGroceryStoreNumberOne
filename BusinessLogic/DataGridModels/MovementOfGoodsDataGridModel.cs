using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataGridModels
{
    public class MovementOfGoodsDataGridModel
    {
        public string id { get; set; }

        [DisplayName("Дата поступления")]
        public string date { get; set; }

        [DisplayName("Тип")]
        public string type { get; set; }
        public List<TablePartModel> tableParts { get; set;}
    }
}
