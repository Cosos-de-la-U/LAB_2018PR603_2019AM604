using System.ComponentModel.DataAnnotations;

namespace LAB_2018PR603_2019AM604.Models { 

    public class Alumno
    {
        [Key]
        public int id { get; set; }
        public string carnet { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dui { get; set; }
        public int departamentoId { get; set; }
        public int estado { get; set; }

    }
}