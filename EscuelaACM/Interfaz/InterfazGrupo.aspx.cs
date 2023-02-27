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
    public partial class InterfazGrupo : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:44351/");
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultarGrupos();
        }

        protected void BtnEnviar2_Click(object sender, EventArgs e)
        {
            Grupo grupo = new Grupo
            {
                NombreGrupo = txtGrupo.Text,
                Aula = int.Parse(intAula.Text)
            };

            String JsonEnviar = JsonConvertidor.Objeto_Json(grupo);
            peticion.PedirComunicacion("Grupo/Insertar", MetodoHTTP.POST, TipoContenido.JSON);
            peticion.enviarDatos(JsonEnviar);
            String JsonRecibir = peticion.ObtenerJson();

            ConsultarGrupos();
        }

        private void ConsultarGrupos()
        {
            peticion.PedirComunicacion("Grupo/ConsultarGrupos", MetodoHTTP.GET, TipoContenido.JSON);
            String JsonRecibir = peticion.ObtenerJson();

            List<GrupoDTO> grupos = JsonConvertidor.Json_ListaObjeto<GrupoDTO>(JsonRecibir);

            gvGrupos.DataSource = grupos;
            gvGrupos.DataBind();
        }
    }
}