namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsTookPlace = c.Boolean(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Pesel = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                        Sex = c.String(),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientVisits", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.PatientVisits", new[] { "Doctor_Id" });
            DropTable("dbo.PatientVisits");
        }
    }
}
