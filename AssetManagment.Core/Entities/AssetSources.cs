using SqlSugar;

namespace AssetManagment.Core.Entities
{
    #region 资产来源
    [SugarTable("sys_asset_sources")]
    public class AssetSources:Entity
    {
        [SugarColumn(ColumnName = "origin")]
        public string Title { get; set; }


        [SugarColumn(ColumnName ="origin_code")]
        public string Code { get; set; }

    }
    #endregion
}
