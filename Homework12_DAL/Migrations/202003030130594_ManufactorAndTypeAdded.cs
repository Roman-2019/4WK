namespace Homework12_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufactorAndTypeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.DetailTypes(NAME) VALUES ('NOT SELECTED')");

            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Manufacturers(NAME) VALUES ('NOT SELECTED')");
            
            AddColumn("dbo.Cars", "ManufacturerId", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Cars SET ManufacturerId = 1");
            AddColumn("dbo.Details", "DetailTypeId", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Details SET DetailTypeId = 1");
            AddColumn("dbo.Details", "ManufacturerId", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Details SET ManufacturerId = 1");
            AlterColumn("dbo.Cars", "Model", c => c.String(maxLength: 20));
            CreateIndex("dbo.Cars", "ManufacturerId");
            CreateIndex("dbo.Details", "DetailTypeId");
            CreateIndex("dbo.Details", "ManufacturerId");
            AddForeignKey("dbo.Details", "DetailTypeId", "dbo.DetailTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "DetailName", c => c.String());
            DropForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Details", "DetailTypeId", "dbo.DetailTypes");
            DropIndex("dbo.Details", new[] { "ManufacturerId" });
            DropIndex("dbo.Details", new[] { "DetailTypeId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            AlterColumn("dbo.Cars", "Model", c => c.String());
            DropColumn("dbo.Details", "ManufacturerId");
            DropColumn("dbo.Details", "DetailTypeId");
            DropColumn("dbo.Details", "Name");
            DropColumn("dbo.Cars", "ManufacturerId");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.DetailTypes");
        }
    }
}
