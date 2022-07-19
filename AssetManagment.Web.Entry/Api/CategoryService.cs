using AssetManagment.Core.Entities;
using AssetManagment.Core.WebApi;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Net;

namespace AssetManagment.Web.Entry.Api
{
    [DynamicApiController]
    public class CategoryService
    {
        private ISqlSugarClient _db;

        public CategoryService(ISqlSugarClient db)
        {
            _db = db;
        }


        [HttpPost("/api/category/add")]
        public ApiResult<string> Add([FromBody]RequestBase data)
        {
            ApiResult<string> result = new ApiResult<string> { Code = 200, Message = "写入数据库成功"};
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                AssetCategory category = new AssetCategory { Title = data.Title, Code = data.Code, Note = data.Note };
                int i = _db.Queryable<AssetCategory>().Where(it => it.Code == category.Code).Count();
                if (i > 0)
                {
                    throw new UniqueExcetion();
                }
                _db.Insertable<AssetCategory>(category).ExecuteCommand();
                _db.Ado.CommitTran();
            } catch(UniqueExcetion)
            {
                result.Code = 301;
                result.Message = "编码重复";
                _db.Ado.RollbackTran();
            }catch (Exception)
            {
                result.Code = 500;
                result.Message = "写入数据库错误";
                _db.Ado.RollbackTran();
            }

            return result;
        }

        [HttpGet("/api/category/get")]
        public ApiResult<List<ResultBase>> Get()
        {
            var result = new ApiResult<List<ResultBase>> { Code = 200, Message = "获取成功"};
            var dresult = new List<ResultBase>();
            try
            {
                var list = _db.Queryable<AssetCategory>().ToList();
                list.ForEach(cate =>
                {
                    dresult.Add(new() { Id = cate.Id, Code = cate.Code, Note = cate.Note, Title = cate.Title});
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

        [HttpPost("/api/category/update")]
        public ApiResult<string> Update([FromBody]RequestBase data)
        {
            var result = new ApiResult<string> { Code = 200, Message = "修改成功"};
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                AssetCategory category = new AssetCategory { Id = data.Id, Code = data.Code, Note = data.Note, Title = data.Title };
                var d = _db.Queryable<AssetCategory>().Where(it => it.Code == category.Code).ToList();
                if (d.Count() == 1 && d.First().Id != data.Id)
                {
                    throw new UniqueExcetion();
                }
                var i = _db.Updateable(category).WhereColumns(it => new { it.Id }).ExecuteCommand();
                if (i == 0) throw new Exception();
                _db.Ado.CommitTran();
            }
            catch(UniqueExcetion)
            {
                result.Code = 301;
                result.Message = "编码重复";
                _db.Ado.RollbackTran();   
            }catch (Exception)
            {
                result.Code = 500;
                result.Message = "修改数据失败";
                _db.Ado.RollbackTran();
            }
            return result;
        }

        [HttpPost("/api/category/remove")]
        public ApiResult<string> Remove([FromBody] int[] list)
        {
            var result = new ApiResult<string> { Code = 200, Message = "删除成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                bool haschange = _db.Deleteable<AssetCategory>().In(list).ExecuteCommandHasChange();
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

    public class UniqueExcetion: Exception
    {

    }
}
