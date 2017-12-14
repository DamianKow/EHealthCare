namespace EHealthCare.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePeselForPatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Pesel", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Pesel", c => c.Int(nullable: false));
        }
    }
}
