using AssetManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagment.Application.Asset
{
    public interface IAssetService
    {
        List<AssetInfo> GetAssetInfos();
        List<AssetInfo> GetAssetInfos(int page);


        #region 资产种类
        void AddAssetCateGory(AssetCategory category);
        void RemoveAssetCateGory(AssetCategory category);
        void UpdateAssetCateGory(AssetCategory category);
        List<AssetCategory> GetAssetCateGories();
        #endregion

        #region 资产来源
        void AddAssetSources(AssetSources source);
        void RemoveAssetSources(AssetSources source);
        void UpdateAssetSources(AssetSources source);
        List<AssetSources> GetAssetSources();
        #endregion

        #region 存储地址
        void AddAssetStorage(AssetStorage storage);
        void RemoveAssetStorage(AssetStorage storage);
        void UpdateAssetStorage(AssetStorage storage);
        List<AssetStorage> GetAssetStorages();
        #endregion

        #region 资产状态
        void AddAssetStatus(AssetStatus status);
        void RemoveAssetStatus(AssetStatus status);
        void UpdateAssetStatus(AssetStatus status);
        List<AssetStatus> GetAssetStatus();
        #endregion

        #region 单位部门
        void AddDepartment(DepartmentInfo department);
        void RemoveDepartment(DepartmentInfo department);
        void UpdateDepartment(DepartmentInfo department);
        List<DepartmentInfo> GetDepartmentes();
        #endregion

        #region 办公人员
        void AddMember(MemberInfo member);
        void RemoveMember(MemberInfo member);
        void UpdateMember(MemberInfo member);
        List<MemberInfo> GetMembers();
        #endregion

        #region 人员状态
        void AddMemberStatus(MemberStatus status);
        void RemoveMemberStatus(MemberStatus status);
        void UpdateMemberStatus(MemberStatus status);
        List<MemberStatus> GetMemberStatuses();
        #endregion

        #region 地区

        void AddRegion(Region region);
        void RemoveRegion(Region region);
        void UpdateRegion(Region region);
        List<Region> GetRegions();
        #endregion

    }
}
