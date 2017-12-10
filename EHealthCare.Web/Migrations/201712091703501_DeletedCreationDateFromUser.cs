namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedCreationDateFromUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "AccountId_Id" });
            RenameColumn(table: "dbo.Patients", name: "AccountId_Id", newName: "AccountId");
            AlterColumn("dbo.Patients", "AccountId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Patients", "AccountId");
            AddForeignKey("dbo.Patients", "AccountId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Patients", "CreationTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "CreationTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Patients", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "AccountId" });
            AlterColumn("dbo.Patients", "AccountId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Patients", name: "AccountId", newName: "AccountId_Id");
            CreateIndex("dbo.Patients", "AccountId_Id");
            AddForeignKey("dbo.Patients", "AccountId_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
