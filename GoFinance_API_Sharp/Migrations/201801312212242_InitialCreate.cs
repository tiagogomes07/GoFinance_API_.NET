namespace GoFinance_API_Sharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lancamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        TipoDC = c.Int(nullable: false),
                        Descrição = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Historico = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lancamentoes");
        }
    }
}
