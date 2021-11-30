using FluentMigrator;
using Unittest.Api.Common;

namespace Unittest.Api.Migrations
{
    [Migration(2021113000001)]
    public class AddCustomerTable : Migration
    {
        public override void Up()
        {
            Create.Table(Constant.CustomerTableName)
                .WithColumn("Id").AsString(250).PrimaryKey()
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("Surname").AsString(250).NotNullable();
        }

        public override void Down()
        {
            
        }
    }
    
    [Migration(2021113000002)]
    public class AddColumnLimitOntoCustomerTable : Migration
    {
        public override void Up()
        {
            Alter.Table(Constant.CustomerTableName)
                .AddColumn("Limit").AsDecimal().Nullable();
        }

        public override void Down()
        {
            
        }
    }
}