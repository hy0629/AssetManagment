using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_storage")]
    public class AssetStorage:Entity
    {
        [SugarColumn(IsIgnore = true)]
        public Region Region { get; set; }

        [SugarColumn(ColumnName ="storage_code", IsNullable = false)]
        public string Code { get; set; }

        [SugarColumn(ColumnName = "storage_title", IsNullable = false)]
        public string Title { get; set; }
    }
}
