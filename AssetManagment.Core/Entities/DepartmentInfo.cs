using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_department_info")]
    public class DepartmentInfo:Entity
    {
        [Navigate(NavigateType.OneToOne, nameof(RegionId))]
        public Region Region { get; set; }

        [SugarColumn(ColumnName = "region_id", IsNullable = false)]
        public int RegionId { get; set; }

        [SugarColumn(ColumnName ="department_code", IsNullable =false )]
        public string Code { get; set; }

        [SugarColumn(ColumnName ="department_title", IsNullable = false)]
        public string Title { get; set; }
    }
}
