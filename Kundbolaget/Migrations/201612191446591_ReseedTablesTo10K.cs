namespace Kundbolaget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReseedTablesTo10K : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('Customers', RESEED, 10000);");
            Sql("DBCC CHECKIDENT ('Orders', RESEED, 10000);");
            Sql("DBCC CHECKIDENT ('Products', RESEED, 10000);");
        }
        
        public override void Down()
        {
            Sql("DBCC CHECKIDENT ('Customers', RESEED, 1);");
            Sql("DBCC CHECKIDENT ('Orders', RESEED, 1);");
            Sql("DBCC CHECKIDENT ('Products', RESEED, 1);");
        }
    }
}
