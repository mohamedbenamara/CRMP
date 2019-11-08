namespace CRMP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfils",
                c => new
                    {
                        UserProfilId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        lastName = c.String(),
                        role = c.String(),
                        gender = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        userAddress = c.String(),
                        userNum = c.Int(nullable: false),
                        point = c.Int(nullable: false),
                        solde = c.Int(nullable: false),
                        internet = c.Int(nullable: false),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.UserProfilId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfils");
        }
    }
}
