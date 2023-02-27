using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscuelaACM.Models
{
    [Table("Tabla-Alumnos")]
    public class Alumno
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String Nombre { get; set; }
        public int Edad { get; set; }   
        public virtual List<GrupoAlumno> Alumnos { get; set; }
    }

    public class AlumnoDTO
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public int Edad { get; set; }
    }
}