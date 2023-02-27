using EscuelaACM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscuelaACM.Controllers
{
    public class AlumnoController : ApiController
    {
        ModeloEscuela bd = new ModeloEscuela();

        [ActionName("Insertar")]
        [HttpPost]

        public bool Insertar(Alumno alumno)
        {
            try
            {
                bd.Alumnos.Add(alumno);
                bd.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("ConsultarAlumnos")]
        [HttpGet]
        public IQueryable<AlumnoDTO> ConsultarAlumnos()
        {
            var consulta = from Alumno in bd.Alumnos
                           select new AlumnoDTO
                           {
                               ID = Alumno.ID,
                               Nombre = Alumno.Nombre,
                               Edad = Alumno.Edad
                           };
            return consulta;
        }
    }
}
