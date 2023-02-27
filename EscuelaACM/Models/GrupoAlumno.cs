using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscuelaACM.Models
{
    [Table("Tabla-GruposAlumnos")]
    public class GrupoAlumno
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int AlumnoID { get; set; }
        public virtual Alumno alumnos { get; set; }
        public int GrupoID { get; set; }
        public virtual Grupo grupos { get; set; }   
    }

    public class GrupoAlumnoDTO
    {
        public int ID { get; set; }
        public int AlumnoID { get; set; }
        public String Nombre { get; set; }
        public int Edad { get; set; }
        public int GrupoID { get; set; }
        public String Grupo { get; set; }
        public int Aula { get; set; }
    }

    public class RelacionDTO
    {
        public int ID { get; set; }
        public String Alumno { get; set; }
        public String Grupo { get; set; }
    }

}