namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientVisit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientVisits", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientVisits", "Prescription_Id", "dbo.Prescriptions");
            DropIndex("dbo.PatientVisits", new[] { "Patient_PatientId" });
            DropIndex("dbo.PatientVisits", new[] { "Prescription_Id" });
            RenameColumn(table: "dbo.PatientVisits", name: "Patient_PatientId", newName: "PatientId");
            RenameColumn(table: "dbo.PatientVisits", name: "Prescription_Id", newName: "PrescriptionId");
            AlterColumn("dbo.PatientVisits", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.PatientVisits", "PrescriptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientVisits", "PrescriptionId");
            CreateIndex("dbo.PatientVisits", "PatientId");
            AddForeignKey("dbo.PatientVisits", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.PatientVisits", "PrescriptionId", "dbo.Prescriptions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisits", "PrescriptionId", "dbo.Prescriptions");
            DropForeignKey("dbo.PatientVisits", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientVisits", new[] { "PatientId" });
            DropIndex("dbo.PatientVisits", new[] { "PrescriptionId" });
            AlterColumn("dbo.PatientVisits", "PrescriptionId", c => c.Int());
            AlterColumn("dbo.PatientVisits", "PatientId", c => c.Int());
            RenameColumn(table: "dbo.PatientVisits", name: "PrescriptionId", newName: "Prescription_Id");
            RenameColumn(table: "dbo.PatientVisits", name: "PatientId", newName: "Patient_PatientId");
            CreateIndex("dbo.PatientVisits", "Prescription_Id");
            CreateIndex("dbo.PatientVisits", "Patient_PatientId");
            AddForeignKey("dbo.PatientVisits", "Prescription_Id", "dbo.Prescriptions", "Id");
            AddForeignKey("dbo.PatientVisits", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
    }
}
