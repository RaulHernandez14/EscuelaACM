using EscuelaACM.Models;
using HTTPupt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EscuelaACM.Interfaz
{
    public partial class InterfazGrupoAlumno : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:44351/");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConsultarGruposAlumnos();
                ConsultarAlumno();
                ConsultarGrupo();
            }
        }

        protected void BtnEnviar3_Click(object sender, EventArgs e)
        {
            GrupoAlumno grupoAlumno = new GrupoAlumno
            {
                AlumnoID = int.Parse(DDLalumno.Text),
                GrupoID = int.Parse(DDLgrupo.Text)
            };

            String jsonEnviar = JsonConvertidor.Objeto_Json(grupoAlumno);
            peticion.PedirComunicacion("GrupoAlumno/Insertar", MetodoHTTP.POST, TipoContenido.JSON);
            peticion.enviarDatos(jsonEnviar);
            String jsonRecibir = peticion.ObtenerJson();

            ConsultarGruposAlumnos();
        }
        
        private void ConsultarGruposAlumnos()
        {
            peticion.PedirComunicacion("GrupoAlumno/ConsultarAlumnosGrupos", MetodoHTTP.GET, TipoContenido.JSON);
            String jsonRecibir = peticion.ObtenerJson();

            List<GrupoAlumnoDTO> grupoAlumnos = JsonConvertidor.Json_ListaObjeto<GrupoAlumnoDTO>(jsonRecibir);
            gvGrupoAlumno.DataSource = grupoAlumnos;
            gvGrupoAlumno.DataBind();
        }

        private void ConsultarAlumno()
        {
            peticion.PedirComunicacion("Alumno/ConsultarAlumnos", MetodoHTTP.GET, TipoContenido.JSON);
            String JsonRecibir = peticion.ObtenerJson();
            List<AlumnoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<AlumnoDTO>(JsonRecibir);

            DDLalumno.DataValueField = "ID";
            DDLalumno.DataTextField = "Nombre";

            DDLalumno.DataSource = alumnos;
            DDLalumno   .DataBind();
        }

        private void ConsultarGrupo()
        {
            peticion.PedirComunicacion("Grupo/ConsultarGrupos", MetodoHTTP.GET, TipoContenido.JSON);
            String JsonRecibir = peticion.ObtenerJson();
            List<GrupoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<GrupoDTO>(JsonRecibir);

            DDLgrupo.DataValueField = "ID";
            DDLgrupo.DataTextField = "Grupo";

            DDLgrupo.DataSource = alumnos;
            DDLgrupo.DataBind();
        }
    }
}