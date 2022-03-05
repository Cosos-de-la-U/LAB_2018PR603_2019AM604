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
    public class AlumnoController : ControllerBase
    {
            private readonly DataContext _context;

            //Inyeccion de dependencias
            public AlumnoController(DataContext context)
            {
                _context = context;
            }

            //Get
            [HttpGet]
            public async Task<ActionResult<List<Alumno>>> Get()
            {
                return Ok(await _context.Alumnos.ToListAsync());
            }
        
            //Get id
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Alumno>>> Get(int id)
            {
                var data= _context.Alumnos.FindAsync(id);
                if (data == null) 
                    return BadRequest();
                return Ok(data);
            }
        
            //Post
            [HttpPost]
            public async Task<ActionResult<List<Alumno>>> Post(Alumno data)
            {
                _context.Alumnos.Add(data);
                await _context.SaveChangesAsync();

                return Ok(await _context.Alumnos.ToListAsync());
            }
        
            //Put
            [HttpPut]
            public async Task<ActionResult<List<Alumno>>> Put(Alumno request)
            {
                var data = await _context.Alumnos.FindAsync(request.id);

                data.carnet = request.carnet;
                data.nombre = request.nombre;
                data.apellidos = request.apellidos;
                data.dui = request.dui;
                data.departamentoId = request.departamentoId;
                data.estado = request.estado;

                await _context.SaveChangesAsync();

                return Ok(data);
            }
    }
}