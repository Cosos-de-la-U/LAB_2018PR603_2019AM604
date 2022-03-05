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
    public class InscripcionController : ControllerBase
    {
            private readonly DataContext _context;

            //Inyeccion de dependencias
            public InscripcionController(DataContext context)
            {
                _context = context;
            }

            //Get
            [HttpGet]
            public async Task<ActionResult<List<Inscripcion>>> Get()
            {
                return Ok(await _context.Inscripciones.ToListAsync());
            }
        
            //Get id
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Inscripcion>>> Get(int id)
            {
                var data= _context.Inscripciones.FindAsync(id);
                if (data == null) 
                    return BadRequest();
                return Ok(data);
            }
        
            //Post
            [HttpPost]
            public async Task<ActionResult<List<Inscripcion>>> Post(Inscripcion data)
            {
                _context.Inscripciones.Add(data);
                await _context.SaveChangesAsync();

                return Ok(await _context.Inscripciones.ToListAsync());
            }
        
            //Put
            [HttpPut]
            public async Task<ActionResult<List<Inscripcion>>> Put(Inscripcion request)
            {
                var data = await _context.Inscripciones.FindAsync(request.id);

                data.id = request.id;
                data.alumnoId = request.alumnoId;
                data.materiaId = request.materiaId;
                data.inscripcion = request.inscripcion;
                data.fecha = request.fecha;
                data.estado = request.estado;

                await _context.SaveChangesAsync();

                return Ok(data);
            }
    }
}