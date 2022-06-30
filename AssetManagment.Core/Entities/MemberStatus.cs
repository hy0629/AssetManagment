using SqlSugar;
using System.Collections.Generic;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_member_status")]
    public class MemberStatus:Entity
    {
        [SugarTable("sys_member_status")]
        public class MemberStatusType : Entity
        {
            [SugarColumn(ColumnName = "status_title")]
            public string Status { get; set; }
        }
    }
}
