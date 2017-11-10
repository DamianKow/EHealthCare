namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountIdToPatients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AccountId_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Patients", "AccountId_Id");
            AddForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "AccountId_Id" });
            DropColumn("dbo.Patients", "AccountId_Id");
        }
    }
}
