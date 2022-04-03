namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnexarTablaProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        ClasiProducID = c.Int(nullable: false),
                        UnidadMedidaID = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Precio = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.ClasiProductos", t => t.ClasiProducID)
                .ForeignKey("dbo.Unidad", t => t.UnidadMedidaID)
                .Index(t => t.ClasiProducID)
                .Index(t => t.UnidadMedidaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "UnidadMedidaID", "dbo.Unidad");
            DropForeignKey("dbo.Productos", "ClasiProducID", "dbo.ClasiProductos");
            DropIndex("dbo.Productos", new[] { "UnidadMedidaID" });
            DropIndex("dbo.Productos", new[] { "ClasiProducID" });
            DropTable("dbo.Productos");
        }
    }
}
