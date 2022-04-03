namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaUnidad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Unidad",
                c => new
                    {
                        UnidadMedidaID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadMedidaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Unidad");
        }
    }
}
