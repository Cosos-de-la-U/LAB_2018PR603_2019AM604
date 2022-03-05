using System.ComponentModel.DataAnnotations;

namespace LAB_2018PR603_2019AM604.Models
{

    public class Facultad
    {
        [Key]
        public int id { get; set; }
        public string facultad { get; set; }

    }
}
