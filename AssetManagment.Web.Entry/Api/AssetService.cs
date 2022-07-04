using AssetManagment.Application.Asset;
using AssetManagment.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagment.Web.Entry.Api
{
    [DynamicApiController]
    public class AssetApiService
    {
        private readonly IAssetService service;
        public AssetApiService(IAssetService assetService)
        {
            service = assetService;
        }

        [HttpPost]
        public string CreateAssetInfo(AssetInfo info)
        {

            return "";
        }
    }
}
