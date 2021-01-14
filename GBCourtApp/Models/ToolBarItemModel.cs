using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCourtApp.Models
{
    public class ToolBarItemModel
    {
        public string ID { get; set; }
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string ImagePath { get; set; }
    }
}
