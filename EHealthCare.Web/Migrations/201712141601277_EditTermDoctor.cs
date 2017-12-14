namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTermDoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Terms", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Terms", new[] { "Doctor_Id" });
            RenameColumn(table: "dbo.Terms", name: "Doctor_Id", newName: "DoctorId");
            AlterColumn("dbo.Terms", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Terms", "DoctorId");
            AddForeignKey("dbo.Terms", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terms", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Terms", new[] { "DoctorId" });
            AlterColumn("dbo.Terms", "DoctorId", c => c.Int());
            RenameColumn(table: "dbo.Terms", name: "DoctorId", newName: "Doctor_Id");
            CreateIndex("dbo.Terms", "Doctor_Id");
            AddForeignKey("dbo.Terms", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
