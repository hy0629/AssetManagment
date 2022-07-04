using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_storage")]
    public class AssetStorage:Entity
    {

        [SugarColumn(IsIgnore =true)]
        [Navigate(NavigateType.OneToOne, nameof(RegionId))]
        public Region Region { get; set; }

        [SugarColumn(ColumnName = "region_id")]
        public int RegionId { get; set; }

        [SugarColumn(ColumnName ="storage_code")]
        public string Code { get; set; }

        [SugarColumn(ColumnName = "storage_title")]
        public string Title { get; set; }
    }
}
