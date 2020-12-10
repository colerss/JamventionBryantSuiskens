namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminKeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "JAM.AdminKeys",
                c => new
                    {
                        KeyID = c.Int(nullable: false, identity: true),
                        HashedPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KeyID);
            
        }
        
        public override void Down()
        {
            DropTable("JAM.AdminKeys");
        }
    }
}
