using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB_2018PR603_2019AM604.Data;
using LAB_2018PR603_2019AM604.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB_2018PR603_2019AM604.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
            private readonly DataContext _context;

            //Inyeccion de dependencias
            public NotaController(DataContext context)
            {
                _context = context;
            }

            //Get
            [HttpGet]
            public async Task<ActionResult<List<Nota>>> Get()
            {
                var data = from n in _context.Notas
                    join i in _context.Inscripciones on n.inscripcionId equals i.id
                    join a in _context.Alumnos on i.alumnoId equals a.id 
                    join m in _context.Materias on i.materiaId equals m.id
                    select new{n.id, a.nombre, a.apellidos, m.materia, n.evaluacion, n.nota, n.porcentaje, n.fecha};

                return Ok(data);
            }
        
            //Get id
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Nota>>> Get(int id)
            {
                var data = (from n in _context.Notas
                    join i in _context.Inscripciones on n.inscripcionId equals i.id
                    join a in _context.Alumnos on i.alumnoId equals a.id 
                    join m in _context.Materias on i.materiaId equals m.id
                    select new{n.id, a.nombre, a.apellidos, m.materia, n.evaluacion, n.nota, n.porcentaje, n.fecha}).FirstOrDefault();
                if (data == null) 
                    return BadRequest();
                return Ok(data);
            }
        
            //Post
            [HttpPost]
            public async Task<ActionResult<List<Nota>>> Post(Nota data)
            {
                _context.Notas.Add(data);
                await _context.SaveChangesAsync();

                return Ok(await _context.Notas.ToListAsync());
            }
        
            //Put
            [HttpPut]
            public async Task<ActionResult<List<Nota>>> Put(Nota request)
            {
                var data = await _context.Notas.FindAsync(request.id);

                data.evaluacion = request.evaluacion;
                data.nota = request.nota;
                data.porcentaje = request.porcentaje;
                data.fecha = request.fecha;

                await _context.SaveChangesAsync();

                return Ok(data);
            }
    }
}