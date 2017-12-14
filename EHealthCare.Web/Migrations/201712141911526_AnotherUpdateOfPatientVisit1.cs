namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherUpdateOfPatientVisit1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientVisits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientVisits", "PrescriptionId", "dbo.Prescriptions");
            DropIndex("dbo.PatientVisits", new[] { "PrescriptionId" });
            DropIndex("dbo.PatientVisits", new[] { "PatientId" });
            RenameColumn(table: "dbo.PatientVisits", name: "PatientId", newName: "Patient_PatientId");
            AlterColumn("dbo.PatientVisits", "PrescriptionId", c => c.Int());
            AlterColumn("dbo.PatientVisits", "Patient_PatientId", c => c.Int());
            CreateIndex("dbo.PatientVisits", "PrescriptionId");
            CreateIndex("dbo.PatientVisits", "Patient_PatientId");
            AddForeignKey("dbo.PatientVisits", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.PatientVisits", "PrescriptionId", "dbo.Prescriptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisits", "PrescriptionId", "dbo.Prescriptions");
            DropForeignKey("dbo.PatientVisits", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.PatientVisits", new[] { "Patient_PatientId" });
            DropIndex("dbo.PatientVisits", new[] { "PrescriptionId" });
            AlterColumn("dbo.PatientVisits", "Patient_PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.PatientVisits", "PrescriptionId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PatientVisits", name: "Patient_PatientId", newName: "PatientId");
            CreateIndex("dbo.PatientVisits", "PatientId");
            CreateIndex("dbo.PatientVisits", "PrescriptionId");
            AddForeignKey("dbo.PatientVisits", "PrescriptionId", "dbo.Prescriptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientVisits", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
        }
    }
}
