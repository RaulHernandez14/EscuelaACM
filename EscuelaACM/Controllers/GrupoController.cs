using EscuelaACM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscuelaACM.Controllers
{
    public class GrupoController : ApiController
    {
        ModeloEscuela bd = new ModeloEscuela();

        [ActionName("Insertar")]
        [HttpPost]

        public bool Insertar(Grupo grupo)
        {
            try
            {
                bd.Grupos.Add(grupo);
                bd.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("ConsultarGrupos")]
        [HttpGet]
        public IQueryable<GrupoDTO> ConsultarGrupos()
        {
            var consulta = from Grupo in bd.Grupos
                           select new GrupoDTO
                           {
                               ID = Grupo.ID,
                               Grupo = Grupo.NombreGrupo,
                               Aula = Grupo.Aula
                           };
            return consulta;
        }
    }
}
