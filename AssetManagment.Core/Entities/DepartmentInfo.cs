using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_department_info")]
    public class DepartmentInfo:Entity
    {
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(RegionId))]
        public Region Region { get; set; }

        [SugarColumn(ColumnName = "region_id")]
        public int RegionId { get; set; }

        [SugarColumn(ColumnName ="department_code")]
        public string Code { get; set; }

        [SugarColumn(ColumnName ="department_title")]
        public string Title { get; set; }
    }
}
