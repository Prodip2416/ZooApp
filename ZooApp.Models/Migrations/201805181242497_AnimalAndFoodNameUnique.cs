namespace ZooApp.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalAndFoodNameUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animals", "IX_AnimalName");
            DropIndex("dbo.Foods", "IX_Food");
            CreateIndex("dbo.Animals", "Name", unique: true, name: "IX_AnimalName");
            CreateIndex("dbo.Foods", "Name", unique: true, name: "IX_Food");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Foods", "IX_Food");
            DropIndex("dbo.Animals", "IX_AnimalName");
            CreateIndex("dbo.Foods", "Name", name: "IX_Food");
            CreateIndex("dbo.Animals", "Name", name: "IX_AnimalName");
        }
    }
}
