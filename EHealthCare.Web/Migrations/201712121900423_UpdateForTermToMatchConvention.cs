namespace EHealthCare.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateForTermToMatchConvention : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Terms");
            DropColumn("dbo.Terms", "Id");
            AddColumn("dbo.Terms", "TermId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Terms", "TermId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Terms", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Terms");
            DropColumn("dbo.Terms", "TermId");
            AddPrimaryKey("dbo.Terms", "Id");
        }
    }
}
