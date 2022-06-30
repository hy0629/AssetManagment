using AssetManagment.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace AssetManagment.Web.Core;
public static class SqlsugarSetup
{
    public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration)
    {
        var con = configuration["ConnectionConfigs:db_test"];
        var configConnection = new ConnectionConfig()
        {
            DbType = DbType.Sqlite,
            ConnectionString = con,
            IsAutoCloseConnection = true,
            InitKeyType = InitKeyType.Attribute
        };

        SqlSugarScope scope = new SqlSugarScope(configConnection, db =>
        {
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                System.Console.WriteLine(sql);
            };
        });
        scope.CodeFirst.InitTables(typeof(AssetInfo), typeof(AssetSources), typeof(AssetStatus), typeof(AssetStorage), typeof(AssetCategory), typeof(DepartmentInfo), typeof(MemberInfo), typeof(MemberStatus), typeof(Region), typeof(User));

        services.AddSingleton<ISqlSugarClient>(scope);

    }
}
