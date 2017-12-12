namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PatientVisits", "MedicalExamination", c => c.String());
            AddColumn("dbo.PatientVisits", "Prescription_Id", c => c.Int());
            AlterColumn("dbo.PatientVisits", "IsTookPlace", c => c.Boolean());
            CreateIndex("dbo.PatientVisits", "Prescription_Id");
            AddForeignKey("dbo.PatientVisits", "Prescription_Id", "dbo.Prescriptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisits", "Prescription_Id", "dbo.Prescriptions");
            DropIndex("dbo.PatientVisits", new[] { "Prescription_Id" });
            AlterColumn("dbo.PatientVisits", "IsTookPlace", c => c.Boolean(nullable: false));
            DropColumn("dbo.PatientVisits", "Prescription_Id");
            DropColumn("dbo.PatientVisits", "MedicalExamination");
            DropTable("dbo.Prescriptions");
        }
    }
}
