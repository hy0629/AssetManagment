using SqlSugar;

namespace AssetManagment.Core.Entities
{
    #region 地区信息
    [SugarTable("sys_region")]
    public class Region:Entity
    {
        [SugarColumn(ColumnName = "region_title")]
        public string Title { get; set; }


        [SugarColumn(ColumnName ="region_code")]
        public string Code { get; set; }
    }
    #endregion
}
