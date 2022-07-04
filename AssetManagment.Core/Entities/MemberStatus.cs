using SqlSugar;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_member_status")]
    public class MemberStatus : Entity
    {
        [SugarColumn(ColumnName = "status_title")]
        public string Status { get; set; }
    }
}
