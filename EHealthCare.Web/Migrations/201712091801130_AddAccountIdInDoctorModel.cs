namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountIdInDoctorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "AccountId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Doctors", "AccountId");
            AddForeignKey("dbo.Doctors", "AccountId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "AccountId" });
            DropColumn("dbo.Doctors", "AccountId");
        }
    }
}
