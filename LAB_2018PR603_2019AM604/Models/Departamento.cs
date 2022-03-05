using System.ComponentModel.DataAnnotations;

namespace LAB_2018PR603_2019AM604.Models;

public class Departamento
{
    [Key]
    public int id { get; set; }
    public string departamento { get; set; }
}