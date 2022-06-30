using SqlSugar;
using System;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_asset_info")]
    public class AssetInfo:Entity
    {
        [SugarColumn(ColumnName ="create_time", IsNullable =false)]
        public string CreateTime { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(UserId))]
        public User User { get; set; }

        [SugarColumn(ColumnName = "user_id", IsNullable = false)]
        public int UserId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(CategoryId))]
        public AssetCategory Category { get; set; }

        [SugarColumn(ColumnName = "category_id", IsNullable = false)]
        public int CategoryId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(SourceId))]
        public AssetSources Sources { get; set; }

        [SugarColumn(ColumnName = "source_id", IsNullable = false)]
        public int SourceId { get; set; }

        [SugarColumn(ColumnName = "asset_number")]
        public string AssetNumber { get; set; }

        [SugarColumn(ColumnName ="asset_name", IsNullable = false)]
        public string AssetName { get; set; }

        [SugarColumn(ColumnName = "asset_spec", IsNullable = false)]
        public string AssetSpec { get; set; }

        [SugarColumn(ColumnName = "asset_unit", IsNullable = false)]
        public string AssetUnit { get; set; }

        [SugarColumn(ColumnName = "asset_value")]
        public string AssetValue { get; set; }

        [SugarColumn(ColumnName = "price")]
        public string Price { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(AssetStstusId))]
        public AssetStatus AssetStatus { get; set; }

        [SugarColumn(ColumnName = "asset_status_id", IsNullable = false)]
        public int AssetStstusId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(AssetStorageId))]
        public AssetStorage AssetStorage { get; set; }

        [SugarColumn(ColumnName = "asset_storage_id", IsNullable = false)]
        public int AssetStorageId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(DepartmentId))]
        public DepartmentInfo Department { get; set; }

        [SugarColumn(ColumnName = "department_id", IsNullable = false)]
        public int DepartmentId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(AssetUsersId))]
        public MemberInfo AssetUsers { get; set; }

        [SugarColumn(ColumnName = "asset_users_id", IsNullable = false)]
        public int AssetUsersId { get; set; }

        [SugarColumn(ColumnName = "asset_pickup_time")]
        public DateTime PickupTime { get; set; }



    }
}
