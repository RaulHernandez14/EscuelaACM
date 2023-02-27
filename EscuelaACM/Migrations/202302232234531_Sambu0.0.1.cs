namespace EscuelaACM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sambu001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tabla-Alumnos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tabla-GruposAlumnos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AlumnoID = c.Int(nullable: false),
                        GrupoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tabla-Alumnos", t => t.AlumnoID, cascadeDelete: true)
                .ForeignKey("dbo.Tabla-Grupos", t => t.GrupoID, cascadeDelete: true)
                .Index(t => t.AlumnoID)
                .Index(t => t.GrupoID);
            
            CreateTable(
                "dbo.Tabla-Grupos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreGrupo = c.String(nullable: false),
                        Aula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tabla-GruposAlumnos", "GrupoID", "dbo.Tabla-Grupos");
            DropForeignKey("dbo.Tabla-GruposAlumnos", "AlumnoID", "dbo.Tabla-Alumnos");
            DropIndex("dbo.Tabla-GruposAlumnos", new[] { "GrupoID" });
            DropIndex("dbo.Tabla-GruposAlumnos", new[] { "AlumnoID" });
            DropTable("dbo.Tabla-Grupos");
            DropTable("dbo.Tabla-GruposAlumnos");
            DropTable("dbo.Tabla-Alumnos");
        }
    }
}
