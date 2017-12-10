namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorAndClinicModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Pesel = c.String(),
                        Phone = c.String(),
                        Specialization = c.String(),
                        Clinic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.Clinic_Id)
                .Index(t => t.Clinic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Clinic_Id", "dbo.Clinics");
            DropIndex("dbo.Doctors", new[] { "Clinic_Id" });
            DropTable("dbo.Doctors");
            DropTable("dbo.Clinics");
        }
    }
}
