using LAB_2018PR603_2019AM604.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB_2018PR603_2019AM604.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
    
    public DbSet<Facultad> Facultades { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }
    public DbSet<Nota> Notas { get; set; }
    
}