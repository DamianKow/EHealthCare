namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTermConventionAddDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Terms", "DateTimeOfTerm", c => c.DateTime(nullable: false));
            DropColumn("dbo.Terms", "Day");
            DropColumn("dbo.Terms", "Hour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Terms", "Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Terms", "Day", c => c.Int(nullable: false));
            DropColumn("dbo.Terms", "DateTimeOfTerm");
        }
    }
}
