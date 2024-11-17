namespace TinyTotsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinyTots",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                        Race = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        FoodAllergies = c.String(),
                    })
                .PrimaryKey(t => t.RegistrationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinyTots");
        }
    }
}
