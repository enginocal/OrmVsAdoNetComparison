using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using MySql.Data.Entity;

namespace OrmVsAdoNetComparison.Data
{
    public class ComparisonCodeGenerator : MySqlMigrationCodeGenerator
    {
        protected override void Generate(DropIndexOperation dropIndexOperation, IndentedTextWriter writer)
        {
            dropIndexOperation.Table = StripDbo(dropIndexOperation.Table);
            base.Generate(dropIndexOperation, writer);
        }

        private static string StripDbo(string table)
        {
            return table.StartsWith("dbo.") ? table.Substring(4) : table;
        }



    }
}