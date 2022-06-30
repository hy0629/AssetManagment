using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_member_info")]
    public class MemberInfo:Entity
    {
        [SugarColumn(ColumnName = "member_number", IsNullable = false)]
        public string MemberNumber { get; set; }

        [SugarColumn(ColumnName = "name", IsNullable = false)]
        public string Name { get; set; }

        [SugarColumn(ColumnName = "sex", IsNullable = false)]
        public string Sex { get; set; }

        [SugarColumn(ColumnName = "duties")]
        public string Duties { get; set; }

        [SugarColumn(ColumnName = "id_number")]
        public string IdNumber { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(DepartmentId))]
        public DepartmentInfo Department { get; set; }

        [SugarColumn(ColumnName = "department_id", IsNullable = false)]
        public int DepartmentId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(MemberStatusId))]
        public MemberStatus MemberStatus { get; set; }

        [SugarColumn(ColumnName = "member_status_id", IsNullable = false)]
        public int MemberStatusId { get; set; }

    }
}
