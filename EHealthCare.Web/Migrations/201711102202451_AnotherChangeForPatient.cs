namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherChangeForPatient : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Patients", name: "AccountId_Id", newName: "AccountId");
            RenameIndex(table: "dbo.Patients", name: "IX_AccountId_Id", newName: "IX_AccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Patients", name: "IX_AccountId", newName: "IX_AccountId_Id");
            RenameColumn(table: "dbo.Patients", name: "AccountId", newName: "AccountId_Id");
        }
    }
}
