using System.ComponentModel.DataAnnotations;

namespace LAB_2018PR603_2019AM604.Models
{

    public class Materia
    {
        [Key]
        public int id { get; set; }
        public int facultadId { get; set; }
        public string materia { get; set; }
        public int unidades_valorativas { get; set; }
        public char estado { get; set; }
    }
}
