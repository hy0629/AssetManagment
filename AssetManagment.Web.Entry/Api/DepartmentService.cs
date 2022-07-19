﻿using AssetManagment.Core.Entities;
using AssetManagment.Core.WebApi;
using AssetManagment.Web.Entry.Api.Exection;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace AssetManagment.Web.Entry.Api
{
    [DynamicApiController]
    public class DepartmentService
    {
        private ISqlSugarClient _db;

        public DepartmentService(ISqlSugarClient db)
        {
            _db = db;
        }

        [HttpPost("/api/department/add")]
        public ApiResult<string> Add([FromBody] RequestWithRegion data)
        {
            ApiResult<string> result = new ApiResult<string> { Code = 200, Message = "写入数据库成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);

                var b = _db.Queryable<Region>().Any(it => it.Id == data.RegionId);
                if (!b) throw new NotFoundExcetion();

                DepartmentInfo department = new DepartmentInfo { Title = data.Title, Code = data.Code, Note = data.Note, RegionId = data.RegionId };
                int i = _db.Queryable<DepartmentInfo>().Where(it => it.Code == department.Code).Count();
                if (i > 0)
                {
                    throw new UniqueExcetion();
                }

                _db.Insertable<DepartmentInfo>(department).ExecuteCommand();
                _db.Ado.CommitTran();
            }
            catch (NotFoundExcetion)
            {
                result.Code = 302;
                result.Message = "不存在区域";
                _db.Ado.RollbackTran();
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

        [HttpGet("/api/department/get")]
        public ApiResult<List<ResultWithRegion>> Get()
        {
            var result = new ApiResult<List<ResultWithRegion>> { Code = 200, Message = "获取成功" };
            try
            {
                var list = _db.Queryable<DepartmentInfo>().Includes(it => it.Region).ToList();
                var dresult = new List<ResultWithRegion>();
                list.ForEach(data =>
                {
                    dresult.Add(new() { Id = data.Id, Code = data.Code, Note = data.Note, Title = data.Title, Region = new BaseData<string> { Id = data.RegionId, Value = $"{data.Region.Code} {data.Region.Title}"} });
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

        [HttpPost("/api/department/update")]
        public ApiResult<string> Update([FromBody] RequestWithRegion data)
        {
            var result = new ApiResult<string> { Code = 200, Message = "修改成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);

                var b = _db.Queryable<Region>().Any(it => it.Id == data.RegionId);
                if (!b) throw new NotFoundExcetion();

                DepartmentInfo department = new DepartmentInfo { Id = data.Id, Code = data.Code, Note = data.Note, Title = data.Title, RegionId = data.RegionId };
                var d = _db.Queryable<DepartmentInfo>().Where(it => it.Code == department.Code).ToList();
                if (d.Count() == 1 && d.First().Id != data.Id)
                {
                    throw new UniqueExcetion();
                }

                var i = _db.Updateable(department).WhereColumns(it => new { it.Id }).ExecuteCommand();
                if (i == 0) throw new Exception();
                _db.Ado.CommitTran();
            }
            catch (NotFoundExcetion)
            {
                result.Code = 302;
                result.Message = "不存在区域";
                _db.Ado.RollbackTran();
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

        [HttpPost("/api/department/remove")]
        public ApiResult<string> Remove([FromBody] int[] list)
        {
            var result = new ApiResult<string> { Code = 200, Message = "删除成功" };
            try
            {
                _db.Ado.BeginTran(System.Data.IsolationLevel.Serializable);
                bool haschange = _db.Deleteable<DepartmentInfo>().In(list).ExecuteCommandHasChange();
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
