namespace IntroductoryProject3._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        gender_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.gender_id);
            
            CreateTable(
                "dbo.Lawyer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Initials = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender_id = c.Int(nullable: false),
                        Title_id = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        title_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.title_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Title");
            DropTable("dbo.Lawyer");
            DropTable("dbo.Gender");
        }
    }
}
