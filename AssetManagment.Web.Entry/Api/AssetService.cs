using AssetManagment.Application.Asset;
using AssetManagment.Core.Entities;
using AssetManagment.Core.WebApi;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagment.Web.Entry.Api
{
    [DynamicApiController]
    public class AssetApiService
    {
        private readonly IAssetService service;
        private readonly IJsonSerializerProvider jsonSerializer;
        public AssetApiService(IAssetService assetService, IJsonSerializerProvider jsonSerializer)
        {
            service = assetService;
            this.jsonSerializer = jsonSerializer;
        }

        [HttpPost]
        public ApiResult<string> CreateAssetInfo(AssetInfoRequest info)
        {
            var data = new AssetInfo
            {

            };
            var result = service.AddAssetInfo(data);
            return new ApiResult<string>
            {
                Code = result > 0 ? 200 : 500,
                Message = result > 0 ? "添加资产成功" : "添加失败",
                Data = null
            };

        }

        public ApiResult<List<AssetInfoResult>> GetAssetInfos()
        {
            List<AssetInfo> assetinfos = service.GetAssetInfos();
            List<AssetInfoResult> data = new List<AssetInfoResult>();
            assetinfos.ForEach((AssetInfo info) =>
            {
                data.Add(new AssetInfoResult { 
                    AssetNumber = info.AssetNumber,
                    AssetSource = info.Sources.Origin,
                    AssetState = info.AssetStatus.Title,
                    Region = info.Region.Title,
                    Storage = info.AssetStorage.Title,
                    Department = info.Department.Title,
                    Member = info.AssetUsers.Name,
                    AssetName = info.AssetName,
                    AssetSpec = info.AssetSpec,
                    AssetUnit = info.AssetUnit,
                    AssetPrice = info.Price,
                    Registrar = info.User.Id.ToString(),
                    UsedTime = info.PickupTime.ToString("yyyy/MM/dd"),
                    RecordTime = info.CreateTime.ToString("yyyy/MM/dd"),
                    ServiceLife = info.ServiceLife,
                    Note = info.Note,
                    Category = info.Category.Title

                });
            });
            return new ApiResult<List<AssetInfoResult>> { Code = 200, Message = "success", Data = data };
        }
    }
}
