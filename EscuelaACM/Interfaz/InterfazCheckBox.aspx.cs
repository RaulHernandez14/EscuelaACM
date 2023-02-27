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
    public partial class InterfazCheckBox : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:50022/");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConsultarAlumnos();
                ConsultarGrupo();
                ConsultarRelacion();
            }
        }

        protected void BtnEnviar4_Click(object sender, EventArgs e)
        {
            List<GrupoAlumno> grupoalumno = new List<GrupoAlumno>();

            foreach (GridViewRow registro in gvAlumnos.Rows)
            {
                CheckBox seleccion = (CheckBox)registro.FindControl("CheckAlumno");

                if (seleccion.Checked)
                {
                    GrupoAlumno grupoalumno2 = new GrupoAlumno()
                    {
                        AlumnoID = int.Parse(registro.Cells[1].Text),
                        GrupoID = int.Parse(DDLgrupo.SelectedValue)
                    };

                    grupoalumno.Add(grupoalumno2);
                }
            }

            String JsonEnviar = JsonConvertidor.Objeto_Json(grupoalumno);
            peticion.PedirComunicacion("GrupoAlumno/CheckBox", MetodoHTTP.POST, TipoContenido.JSON);
            peticion.enviarDatos(JsonEnviar);
            String JsonRecibir = peticion.ObtenerJson();

            ConsultarAlumnos();
            ConsultarGrupo();
            ConsultarRelacion();
        }
        public void ConsultarAlumnos()
        {
            peticion.PedirComunicacion("Alumno/ConsultarAlumnos", MetodoHTTP.GET, TipoContenido.JSON);
            String jsonRecibir = peticion.ObtenerJson();

            List<AlumnoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<AlumnoDTO>(jsonRecibir);

            gvAlumnos.DataSource = alumnos;
            gvAlumnos.DataBind();
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

        private void ConsultarRelacion()
        {
            peticion.PedirComunicacion("GrupoAlumno/MostrarRelacion", MetodoHTTP.GET, TipoContenido.JSON);
            String jsonRecibir = peticion.ObtenerJson();

            List<RelacionDTO> alumnos = JsonConvertidor.Json_ListaObjeto<RelacionDTO>(jsonRecibir);

            gvRelacion.DataSource = alumnos;
            gvRelacion.DataBind();
        }

    }
}