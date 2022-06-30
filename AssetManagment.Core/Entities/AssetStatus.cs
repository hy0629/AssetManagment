using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagment.Core.Entities
{
    #region 资产状况
    [SugarTable("sys_asset_status")]
    public class AssetStatus
    {
        [SugarColumn(ColumnName ="status_title", IsNullable = false)]
        public string Title { get; set; }

        [SugarColumn(ColumnName ="status_code", IsNullable = false)]
        public string Code { get; set; }
    }
    #endregion
}
