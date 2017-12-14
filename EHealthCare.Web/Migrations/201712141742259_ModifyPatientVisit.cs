namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPatientVisit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientVisits", "Patient_PatientId", c => c.Int());
            CreateIndex("dbo.PatientVisits", "Patient_PatientId");
            AddForeignKey("dbo.PatientVisits", "Patient_PatientId", "dbo.Patients", "PatientId");
            DropColumn("dbo.PatientVisits", "Name");
            DropColumn("dbo.PatientVisits", "Surname");
            DropColumn("dbo.PatientVisits", "Pesel");
            DropColumn("dbo.PatientVisits", "Age");
            DropColumn("dbo.PatientVisits", "Phone");
            DropColumn("dbo.PatientVisits", "City");
            DropColumn("dbo.PatientVisits", "Street");
            DropColumn("dbo.PatientVisits", "PostCode");
            DropColumn("dbo.PatientVisits", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientVisits", "Sex", c => c.String());
            AddColumn("dbo.PatientVisits", "PostCode", c => c.String());
            AddColumn("dbo.PatientVisits", "Street", c => c.String());
            AddColumn("dbo.PatientVisits", "City", c => c.String());
            AddColumn("dbo.PatientVisits", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.PatientVisits", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.PatientVisits", "Pesel", c => c.Int(nullable: false));
            AddColumn("dbo.PatientVisits", "Surname", c => c.String());
            AddColumn("dbo.PatientVisits", "Name", c => c.String());
            DropForeignKey("dbo.PatientVisits", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.PatientVisits", new[] { "Patient_PatientId" });
            DropColumn("dbo.PatientVisits", "Patient_PatientId");
        }
    }
}
