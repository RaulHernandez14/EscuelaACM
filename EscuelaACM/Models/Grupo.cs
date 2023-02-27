using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscuelaACM.Models
{
    [Table("Tabla-Grupos")]
    public class Grupo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String NombreGrupo { get; set; }
        public int Aula { get; set; }
        public virtual List<GrupoAlumno> Grupos { get; set; }
    }

    public class GrupoDTO
    {
        public int ID { get; set; }
        public String Grupo { get; set; }
        public int Aula { get; set; }
    }
}