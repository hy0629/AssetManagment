using AssetManagment.Core.Entities;
using AssetManagment.Core.WebApi;
using AssetManagment.Web.Entry.Api.Exection;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace AssetManagment.Web.Entry.Api
{
    [DynamicApiController]
    public class RegionService
    {
        private ISqlSugarClient _db;

        public RegionService(ISqlSugarClient db)
        {
            _db = db;
        }


        [HttpPost("/api/region/add")]
        public ApiResult<string> Add([FromBody] RequestBase data)
        {
            ApiResult<string> result = new ApiResult<string> { Code = 200, Message = "写入数据库成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                Region region = new Region { Title = data.Title, Code = data.Code, Note = data.Note };
                int i = _db.Queryable<Region>().Where(it => it.Code == region.Code).Count();
                if (i > 0)
                {
                    throw new UniqueExcetion();
                }
                _db.Insertable<Region>(region).ExecuteCommand();
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

        [HttpGet("/api/region/get")]
        public ApiResult<List<ResultBase>> Get()
        {
            var result = new ApiResult<List<ResultBase>> { Code = 200, Message = "获取成功" };
            try
            {
                var dresult = new List<ResultBase>();
                var list = _db.Queryable<Region>().ToList();
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

        [HttpPost("/api/region/update")]
        public ApiResult<string> Update([FromBody] RequestBase data)
        {
            var result = new ApiResult<string> { Code = 200, Message = "修改成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                Region region = new Region { Id = data.Id, Code = data.Code, Note = data.Note, Title = data.Title };
                var d = _db.Queryable<Region>().Where(it => it.Code == region.Code).ToList();
                if (d.Count() == 1 && d.First().Id != data.Id)
                {
                    throw new UniqueExcetion();
                }
                var i = _db.Updateable(region).WhereColumns(it => new { it.Id }).ExecuteCommand();
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

        [HttpPost("/api/region/remove")]
        public ApiResult<string> Remove([FromBody] int[] list)
        {
            var result = new ApiResult<string> { Code = 200, Message = "删除成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);

                if(_db.Queryable<DepartmentInfo>().Any(it => list.Contains(it.RegionId)) || _db.Queryable<AssetStorage>().Any(it => list.Contains(it.RegionId)))
                {
                    throw new ForeignKeyException();
                }

                bool haschange = _db.Deleteable<Region>().In(list).ExecuteCommandHasChange();
                if (!haschange) throw new Exception();
                _db.Ado.CommitTran();
            }
            catch (ForeignKeyException)
            {
                result.Code = 304;
                result.Message = "外键约束";
                _db.Ado.RollbackTran();
            }
            catch (Exception)
            {
                result.Code = 500;
                result.Message = "删除失败";
                _db.Ado.RollbackTran();
            }
            return result;
        }

        [HttpGet("/api/region/code")]
        public ApiResult<string> GetCode()
        {
            var result = _db.Queryable<Region>().Max(it => it.Code) ?? "00";
            result = (int.Parse(result) + 1).ToString().PadLeft(2, '0');
            return new ApiResult<string>() { Code = 200, Message = "", Data = result?? "01" };
        }
    }
}
