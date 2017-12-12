namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsUsableFieldForTerms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Terms", "IsTaken", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Terms", "IsTaken");
        }
    }
}
