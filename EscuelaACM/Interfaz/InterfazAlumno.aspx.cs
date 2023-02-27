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
    public partial class InterfazAlumno : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:44351/");     
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarAlumnos();
        }

        protected void BtnEnviar1_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno()
            {
                Nombre = txtNombre.Text,
                Edad = int.Parse(intEdad.Text)
            };

            String JsonEnviar = JsonConvertidor.Objeto_Json(alumno);
            peticion.PedirComunicacion("Alumno/Insertar", MetodoHTTP.POST, TipoContenido.JSON);
            peticion.enviarDatos(JsonEnviar);
            String JsonRecibir = peticion.ObtenerJson();

            ConsultarAlumnos();
        }

        public void ConsultarAlumnos()
        {
            peticion.PedirComunicacion("Alumno/ConsultarAlumnos", MetodoHTTP.GET, TipoContenido.JSON);
            String jsonRecibir = peticion.ObtenerJson();
             
            List<AlumnoDTO> alumnos = JsonConvertidor.Json_ListaObjeto<AlumnoDTO>(jsonRecibir);

            gvAlumnos.DataSource = alumnos;
            gvAlumnos.DataBind();
        }
    }
}