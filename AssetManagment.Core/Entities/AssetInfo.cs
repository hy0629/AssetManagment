using SqlSugar;
using System;

namespace AssetManagment.Core.Entities
{
    [SugarTable("sys_asset_info")]
    public class AssetInfo:Entity
    {
        [SugarColumn(ColumnName ="create_time")]
        public string CreateTime { get; set; }

        [SugarColumn(IsIgnore =true)]
        [Navigate(NavigateType.OneToOne, nameof(UserId))]
        public User User { get; set; }

        [SugarColumn(ColumnName = "user_id")]
        public int UserId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(CategoryId))]
        public AssetCategory Category { get; set; }

        [SugarColumn(ColumnName = "category_id")]
        public int CategoryId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SourceId))]
        public AssetSources Sources { get; set; }

        [SugarColumn(ColumnName = "source_id")]
        public int SourceId { get; set; }

        [SugarColumn(ColumnName = "asset_number")]
        public string AssetNumber { get; set; }

        [SugarColumn(ColumnName ="asset_name")]
        public string AssetName { get; set; }

        [SugarColumn(ColumnName = "asset_spec")]
        public string AssetSpec { get; set; }

        [SugarColumn(ColumnName = "asset_unit")]
        public string AssetUnit { get; set; }

        [SugarColumn(ColumnName = "asset_value", IsNullable = true)]
        public string AssetValue { get; set; }

        [SugarColumn(ColumnName = "price", IsNullable = true)]
        public string Price { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(AssetStstusId))]
        public AssetStatus AssetStatus { get; set; }

        [SugarColumn(ColumnName = "asset_status_id")]
        public int AssetStstusId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(AssetStorageId))]
        public AssetStorage AssetStorage { get; set; }

        [SugarColumn(ColumnName = "asset_storage_id")]
        public int AssetStorageId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(DepartmentId))]
        public DepartmentInfo Department { get; set; }

        [SugarColumn(ColumnName = "department_id")]
        public int DepartmentId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(AssetUsersId))]
        public MemberInfo AssetUsers { get; set; }

        [SugarColumn(ColumnName = "asset_users_id")]
        public int AssetUsersId { get; set; }

        [SugarColumn(ColumnName = "asset_pickup_time")]
        public DateTime PickupTime { get; set; }

        [SugarColumn(ColumnName = "region_id")]
        public int RegionId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(RegionId))]
        public Region Region { get; set; }

    }
}
