namespace Homework12_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailNameUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Name", c => c.String());
            DropColumn("dbo.Details", "DetailName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "DetailName", c => c.String());
            DropColumn("dbo.Details", "Name");
        }
    }
}
