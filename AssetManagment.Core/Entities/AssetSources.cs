using SqlSugar;

namespace AssetManagment.Core.Entities
{
    #region 资产来源
    [SugarTable("sys_asset_sources")]
    public class AssetSources:Entity
    {
        [SugarColumn(ColumnName = "origin", IsNullable =false)]
        public string Origin { get; set; }


        [SugarColumn(ColumnName ="origin_code", IsNullable = false)]
        public string Code { get; set; }

    }
    #endregion
}
