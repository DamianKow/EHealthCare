namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPrescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "Doctor_Id", c => c.Int());
            AddColumn("dbo.Prescriptions", "Patient_PatientId", c => c.Int());
            CreateIndex("dbo.Prescriptions", "Doctor_Id");
            CreateIndex("dbo.Prescriptions", "Patient_PatientId");
            AddForeignKey("dbo.Prescriptions", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Prescriptions", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Prescriptions", new[] { "Patient_PatientId" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_Id" });
            DropColumn("dbo.Prescriptions", "Patient_PatientId");
            DropColumn("dbo.Prescriptions", "Doctor_Id");
        }
    }
}
