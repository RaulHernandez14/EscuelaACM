using EscuelaACM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscuelaACM.Controllers
{
    public class GrupoAlumnoController : ApiController
    {
        ModeloEscuela bd = new ModeloEscuela();

        [ActionName("Insertar")]
        [HttpPost]

        public bool Insertar(GrupoAlumno grupoAlumno)
        {
            try
            {
                bd.GruposAlumnos.Add(grupoAlumno);
                bd.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("ConsultaRegAlumno")]
        [HttpGet]

        public IQueryable<GrupoAlumnoDTO> ConsultaRegAlumno(int ID)
        {
            var consulta = from GrupoAlumno in bd.GruposAlumnos
                           where GrupoAlumno.ID == ID
                           select new GrupoAlumnoDTO
                           {
                               ID = GrupoAlumno.ID,
                               Nombre = GrupoAlumno.alumnos.Nombre,
                               Edad = GrupoAlumno.alumnos.Edad,
                               AlumnoID = GrupoAlumno.alumnos.ID,
                               Grupo = GrupoAlumno.grupos.NombreGrupo,
                               Aula = GrupoAlumno.grupos.Aula,
                               GrupoID = GrupoAlumno.grupos.ID
                           };
            return consulta;
        }
        [ActionName("ConsultarAlumnosGrupos")]
        [HttpGet]

        public IQueryable<GrupoAlumnoDTO> ConsultarAlumnosGrupos()
        {
            var consulta = from GrupoAlumno in bd.GruposAlumnos
                           select new GrupoAlumnoDTO
                           {
                               ID = GrupoAlumno.ID,
                               Nombre = GrupoAlumno.alumnos.Nombre,
                               Edad = GrupoAlumno.alumnos.Edad,
                               AlumnoID = GrupoAlumno.alumnos.ID,
                               Grupo = GrupoAlumno.grupos.NombreGrupo,
                               Aula = GrupoAlumno.grupos.Aula,
                               GrupoID = GrupoAlumno.grupos.ID
                           };
            return consulta;
        }

        [ActionName("MostrarRelacion")]
        [HttpGet]

        public IQueryable<RelacionDTO> MostrarRelacion()
        {
            var consulta = from GrupoAlumno in bd.GruposAlumnos
                           select new RelacionDTO
                           {
                               ID = GrupoAlumno.ID,
                               Alumno = GrupoAlumno.alumnos.Nombre,
                               Grupo = GrupoAlumno.grupos.NombreGrupo
                           };

            return consulta;
        }

        [ActionName("CheckBox")]
        [HttpPost]

        public void CheckBox(List<GrupoAlumno> grupoAlumno)
        {
            foreach(GrupoAlumno Grupolumno in grupoAlumno)
            {
                var consulta = bd.GruposAlumnos.Where(c => c.GrupoID == Grupolumno.GrupoID && c.AlumnoID == Grupolumno.AlumnoID);

                if (consulta.Count() == 0)
                { 
                    bd.GruposAlumnos.Add(Grupolumno); // bd.Tabla en el modelo.Add(Nombre del objeto recien creado en el foreach);
                    bd.SaveChangesAsync();
                }
            }
        }


    }
}
