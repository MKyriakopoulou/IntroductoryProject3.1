namespace DTOlibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.genderDTO",
                c => new
                {
                    gender_id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.gender_id);

            CreateTable(
                "dbo.lawyerDTO",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Surname = c.String(),
                    Initials = c.String(),
                    DateOfBirth = c.DateTime(nullable: false),
                    Gender = c.Int(nullable: false),
                    Title = c.Int(nullable: false),
                    Email = c.String(),
                    Genderdto_gender_id = c.Int(),
                    Titledto_title_id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.genderDTO", t => t.Genderdto_gender_id)
                .ForeignKey("dbo.titleDTO", t => t.Titledto_title_id)
                .Index(t => t.Genderdto_gender_id)
                .Index(t => t.Titledto_title_id);

            CreateTable(
                "dbo.titleDTO",
                c => new
                {
                    title_id = c.Int(nullable: false, identity: true),
                    description = c.String(),
                })
                .PrimaryKey(t => t.title_id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.lawyerDTO", "Titledto_title_id", "dbo.titleDTO");
            DropForeignKey("dbo.lawyerDTO", "Genderdto_gender_id", "dbo.genderDTO");
            DropIndex("dbo.lawyerDTO", new[] { "Titledto_title_id" });
            DropIndex("dbo.lawyerDTO", new[] { "Genderdto_gender_id" });
            DropTable("dbo.titleDTO");
            DropTable("dbo.lawyerDTO");
            DropTable("dbo.genderDTO");
        }
    }
}
