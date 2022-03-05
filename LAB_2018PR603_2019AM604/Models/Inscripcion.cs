using System.ComponentModel.DataAnnotations;

namespace LAB_2018PR603_2019AM604.Models
{

    public class Inscripcion
    {
        [Key]
        public int id { get; set; }
        public int alumnoId { get; set; }
        public int materiaId { get; set; }
        public int inscripcion { get; set; }
        public DateTime fecha { get; set; }
        public char estado { get; set; }
    }
}
