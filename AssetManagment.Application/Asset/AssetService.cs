using AssetManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagment.Application.Asset
{
    public class AssetService:IAssetService, ITransient
    {
        private ISqlSugarClient _db;
        public AssetService(ISqlSugarClient db)
        {
            _db = db;
        }

        public void AddAssetCateGory(AssetCategory category)
        {
            _db.Insertable<AssetCategory>(category).ExecuteReturnIdentity();
        }

        public int AddAssetInfo(AssetInfo info)
        {
            return _db.Insertable<AssetInfo>(info).ExecuteReturnIdentity();
        }

        public void AddAssetSources(AssetSources source)
        {
            _db.Insertable<AssetSources>(source).ExecuteReturnIdentity();
        }

        public void AddAssetStatus(AssetStatus status)
        {
            _db.Insertable<AssetStatus>(status).ExecuteReturnIdentity();
        }

        public void AddAssetStorage(AssetStorage storage)
        {
            _db.Insertable<AssetStorage>(storage).ExecuteReturnIdentity();
        }

        public void AddDepartment(DepartmentInfo department)
        {
            _db.Insertable<DepartmentInfo>(department).ExecuteReturnIdentity();
        }

        public void AddMember(MemberInfo member)
        {
            _db.Insertable<MemberInfo>(member).ExecuteReturnIdentity();
        }

        public void AddMemberStatus(MemberStatus status)
        {
            _db.Insertable<MemberStatus>(status).ExecuteReturnIdentity();
        }

        public void AddRegion(Region region)
        {
            _db.Insertable<Region>(region).ExecuteReturnIdentity();
        }

        public List<AssetCategory> GetAssetCateGories()
        {
            return _db.Queryable<AssetCategory>().ToList();
        }

        public List<AssetInfo> GetAssetInfos()
        {
            return _db.Queryable<AssetInfo>().Includes(x => x.Region).Includes(x => x.User).Includes(x => x.Category).Includes(x => x.Sources).Includes(x => x.AssetStatus).Includes(x => x.AssetStorage).Includes(x => x.Department).Includes(x => x.AssetUsers).ToList();
        }

        public List<AssetInfo> GetAssetInfos(int page)
        {
            return _db.Queryable<AssetInfo>().Includes(x => x.Region).Includes(x => x.User).Includes(x => x.Category).Includes(x => x.Sources).Includes(x => x.AssetStatus).Includes(x => x.AssetStorage).Includes(x => x.Department).Includes(x => x.AssetUsers).ToPageList(page, 20);
        }

        public List<AssetSources> GetAssetSources()
        {
            return _db.Queryable<AssetSources>().ToList();
        }

        public List<AssetStatus> GetAssetStatus()
        {
            return _db.Queryable<AssetStatus>().ToList();
        }

        public List<AssetStorage> GetAssetStorages()
        {
            return _db.Queryable<AssetStorage>().ToList();
        }

        public List<DepartmentInfo> GetDepartmentes()
        {
            return _db.Queryable<DepartmentInfo>().ToList();
        }

        public List<MemberInfo> GetMembers()
        {
            return _db.Queryable<MemberInfo>().ToList();
        }

        public List<MemberStatus> GetMemberStatuses()
        {
            return _db.Queryable<MemberStatus>().ToList();
        }

        public List<Region> GetRegions()
        {
            return _db.Queryable<Region>().ToList();
        }

        public void RemoveAssetCateGory(AssetCategory category)
        {
            _db.Deleteable<AssetCategory>().Where(it => it.Id == category.Id).ExecuteCommandHasChange();
        }

        public void RemoveAssetSources(AssetSources source)
        {
            _db.Deleteable<AssetSources>().Where(it => it.Id == source.Id).ExecuteCommandHasChange();
        }

        public void RemoveAssetStatus(AssetStatus status)
        {
            _db.Deleteable<AssetStatus>().Where(it => it.Id == status.Id).ExecuteCommandHasChange();
        }

        public void RemoveAssetStorage(AssetStorage storage)
        {
            _db.Deleteable<AssetStorage>().Where(it => it.Id == storage.Id).ExecuteCommandHasChange();
        }

        public void RemoveDepartment(DepartmentInfo department)
        {
            _db.Deleteable<DepartmentInfo>().Where(it => it.Id == department.Id).ExecuteCommandHasChange();
        }

        public void RemoveMember(MemberInfo member)
        {
            _db.Deleteable<MemberInfo>().Where(it => it.Id == member.Id).ExecuteCommandHasChange();
        }

        public void RemoveMemberStatus(MemberStatus status)
        {
            _db.Deleteable<MemberStatus>().Where(it => it.Id == status.Id).ExecuteCommandHasChange();
        }

        public void RemoveRegion(Region region)
        {
            _db.Deleteable<Region>().Where(it => it.Id == region.Id).ExecuteCommandHasChange();

        }

        public void UpdateAssetCateGory(AssetCategory category)
        {
            _db.Updateable<AssetCategory>(category).IgnoreColumns("Id").ExecuteCommandHasChange();
        }

        public void UpdateAssetSources(AssetSources source)
        {
            _db.Updateable<AssetSources>(source).IgnoreColumns("Id").ExecuteCommandHasChange();

        }

        public void UpdateAssetStatus(AssetStatus status)
        {
            _db.Updateable<AssetStatus>(status).IgnoreColumns("Id").ExecuteCommandHasChange();
        }

        public void UpdateAssetStorage(AssetStorage storage)
        {
            _db.Updateable<AssetStorage>(storage).IgnoreColumns("Id").ExecuteCommandHasChange();
        }

        public void UpdateDepartment(DepartmentInfo department)
        {
            _db.Updateable<DepartmentInfo>(department).IgnoreColumns("Id").ExecuteCommandHasChange();
        }

        public void UpdateMember(MemberInfo member)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberStatus(MemberStatus status)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegion(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
