using SqlSugar;

namespace AssetManagment.Core.Entities
{
    public class Entity
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true, ColumnName = "id")]
        public int Id { get; set; }

        [SugarColumn(ColumnName ="note", IsNullable = true)]
        public string Note { get; set; }
    }
}
