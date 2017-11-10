namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAccountIdForPatient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "AccountId_Id" });
            AlterColumn("dbo.Patients", "AccountId_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Patients", "AccountId_Id");
            AddForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "AccountId_Id" });
            AlterColumn("dbo.Patients", "AccountId_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Patients", "AccountId_Id");
            AddForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
