using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_member_info")]
    public class MemberInfo:Entity
    {
        [SugarColumn(ColumnName = "member_number")]
        public string MemberNumber { get; set; }

        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }

        [SugarColumn(ColumnName = "sex")]
        public string Sex { get; set; }

        [SugarColumn(ColumnName = "duties")]
        public string Duties { get; set; }

        [SugarColumn(ColumnName = "id_number")]
        public string IdNumber { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(DepartmentId))]
        public DepartmentInfo Department { get; set; }

        [SugarColumn(ColumnName = "department_id")]
        public int DepartmentId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(MemberStatusId))]
        public MemberStatus MemberStatus { get; set; }

        [SugarColumn(ColumnName = "member_status_id")]
        public int MemberStatusId { get; set; }

    }
}
