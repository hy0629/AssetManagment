using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlSugar;

namespace AssetManagment.Core.Entities
{
    #region 资产类别
    [SugarTable("sys_category")]
    public class AssetCategory:Entity
    {

        [SugarColumn(ColumnName ="category_title")]
        public string Title { get; set; }


        [SugarColumn(ColumnName ="category_code")]
        public string Code { get; set; }

    }
    #endregion

}
