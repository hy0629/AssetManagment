using AssetManagment.Core.Entities;
using AssetManagment.Core.WebApi;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace AssetManagment.Web.Entry.Api
{
    [DynamicApiController]
    public class AssetStatusService
    {
        private ISqlSugarClient _db;

        public AssetStatusService(ISqlSugarClient db)
        {
            _db = db;
        }


        [HttpPost("/api/assetstatus/add")]
        public ApiResult<string> Add([FromBody] RequestBase data)
        {
            ApiResult<string> result = new ApiResult<string> { Code = 200, Message = "写入数据库成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                AssetStatus status = new AssetStatus { Title = data.Title, Code = data.Code, Note = data.Note };
                int i = _db.Queryable<AssetStatus>().Where(it => it.Code == status.Code).ToList().Count();
                if (i > 0)
                {
                    throw new UniqueExcetion();
                }
                _db.Insertable<AssetStatus>(status).ExecuteCommand();
                _db.Ado.CommitTran();
            }
            catch (UniqueExcetion)
            {
                result.Code = 301;
                result.Message = "编码重复";
                _db.Ado.RollbackTran();
            }
            catch (Exception)
            {
                result.Code = 500;
                result.Message = "写入数据库错误";
                _db.Ado.RollbackTran();
            }

            return result;
        }

        [HttpGet("/api/assetstatus/get")]
        public ApiResult<List<ResultBase>> Get()
        {
            var result = new ApiResult<List<ResultBase>> { Code = 200, Message = "获取成功" };
            try
            {
                var list = _db.Queryable<AssetStatus>().ToList();
                List<ResultBase> dresult = new();
                list.ForEach(cate =>
                {
                    dresult.Add(new() { Id = cate.Id, Code = cate.Code, Note = cate.Note, Title = cate.Title });
                });
                result.Data = dresult;
            }
            catch (Exception)
            {
                result.Code = 500;
                result.Message = "读取数据失败";
            }
            return result;
        }

        [HttpPost("/api/assetstatus/update")]
        public ApiResult<string> Update([FromBody] RequestBase data)
        {
            var result = new ApiResult<string> { Code = 200, Message = "修改成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                AssetStatus status = new AssetStatus { Id = data.Id, Code = data.Code, Note = data.Note, Title = data.Title };
                var d = _db.Queryable<AssetStatus>().Where(it => it.Code == status.Code).ToList();
                if (d.Count() == 1 && d.First().Id != data.Id)
                {
                    throw new UniqueExcetion();
                }
                var i = _db.Updateable(status).WhereColumns(it => new { it.Id }).ExecuteCommand();
                if (i == 0) throw new Exception();
                _db.Ado.CommitTran();
            }
            catch (UniqueExcetion)
            {
                result.Code = 301;
                result.Message = "编码重复";
                _db.Ado.RollbackTran();
            }
            catch (Exception)
            {
                result.Code = 500;
                result.Message = "修改数据失败";
                _db.Ado.RollbackTran();
            }
            return result;
        }

        [HttpPost("/api/assetstatus/remove")]
        public ApiResult<string> Remove([FromBody] int[] list)
        {
            var result = new ApiResult<string> { Code = 200, Message = "删除成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                bool haschange = _db.Deleteable<AssetStatus>().In(list).ExecuteCommandHasChange();
                if (!haschange) throw new Exception();
                _db.Ado.CommitTran();
            }
            catch (Exception)
            {
                result.Code = 500;
                result.Message = "删除失败";
                _db.Ado.RollbackTran();
            }
            return result;
        }
    }
}

