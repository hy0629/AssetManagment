using SqlSugar;

namespace AssetManagment.Core.Entities
{
    public class Entity
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true, ColumnName = "id", IsNullable = false)]
        public int Id { get; set; }

        [SugarColumn(ColumnName ="note")]
        public string Note { get; set; }
    }
}
