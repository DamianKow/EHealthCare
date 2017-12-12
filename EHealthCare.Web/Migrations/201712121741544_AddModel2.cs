namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActiveSubstance = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrecriptionMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Medicines_Id = c.Int(),
                        Prescription_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicines", t => t.Medicines_Id)
                .ForeignKey("dbo.Prescriptions", t => t.Prescription_Id)
                .Index(t => t.Medicines_Id)
                .Index(t => t.Prescription_Id);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terms", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PrecriptionMedicines", "Prescription_Id", "dbo.Prescriptions");
            DropForeignKey("dbo.PrecriptionMedicines", "Medicines_Id", "dbo.Medicines");
            DropIndex("dbo.Terms", new[] { "Doctor_Id" });
            DropIndex("dbo.PrecriptionMedicines", new[] { "Prescription_Id" });
            DropIndex("dbo.PrecriptionMedicines", new[] { "Medicines_Id" });
            DropTable("dbo.Terms");
            DropTable("dbo.PrecriptionMedicines");
            DropTable("dbo.Medicines");
        }
    }
}
