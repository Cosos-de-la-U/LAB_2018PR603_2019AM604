using System.ComponentModel.DataAnnotations;

namespace LAB_2018PR603_2019AM604.Models
{

    public class Nota
    {
        [Key]
        public int id { get; set; }
        public int inscripcionId { get; set; }
        public string evaluacion { get; set; }
        public double nota { get; set; }
        public double porcentaje { get; set; }
        public DateTime fecha { get; set; }
    }
}