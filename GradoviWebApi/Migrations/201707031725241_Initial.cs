namespace GradoviWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drzave",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        InternacionalniKod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gradovi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        PostanskiBroj = c.Int(nullable: false),
                        BrojStanovnika = c.Int(nullable: false),
                        DrzavaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drzave", t => t.DrzavaId, cascadeDelete: true)
                .Index(t => t.DrzavaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gradovi", "DrzavaId", "dbo.Drzave");
            DropIndex("dbo.Gradovi", new[] { "DrzavaId" });
            DropTable("dbo.Gradovi");
            DropTable("dbo.Drzave");
        }
    }
}
