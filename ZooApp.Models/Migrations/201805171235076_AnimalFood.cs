namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalFood : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.AnimalId)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "IX_Food");
            
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Animals", "Origin", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Animals", "Name", name: "IX_AnimalName");
            CreateIndex("dbo.Animals", "Origin", name: "IX_AnimalOrigin");
            DropColumn("dbo.Animals", "Food");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Food", c => c.String());
            DropForeignKey("dbo.AnimalFoods", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.AnimalFoods", "AnimalId", "dbo.Animals");
            DropIndex("dbo.Foods", "IX_Food");
            DropIndex("dbo.AnimalFoods", new[] { "FoodId" });
            DropIndex("dbo.AnimalFoods", new[] { "AnimalId" });
            DropIndex("dbo.Animals", "IX_AnimalOrigin");
            DropIndex("dbo.Animals", "IX_AnimalName");
            AlterColumn("dbo.Animals", "Origin", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String());
            DropTable("dbo.Foods");
            DropTable("dbo.AnimalFoods");
        }
    }
}
