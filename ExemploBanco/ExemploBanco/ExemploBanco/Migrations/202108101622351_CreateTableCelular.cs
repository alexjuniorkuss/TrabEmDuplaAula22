namespace ExemploBanco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCelular : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celulars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jogos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Tipo = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jogos");
            DropTable("dbo.Celulars");
        }
    }
}
