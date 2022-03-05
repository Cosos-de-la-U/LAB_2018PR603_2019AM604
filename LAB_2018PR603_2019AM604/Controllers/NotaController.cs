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
                return Ok(await _context.Notas.ToListAsync());
            }
        
            //Get id
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Nota>>> Get(int id)
            {
                var data= _context.Notas.FindAsync(id);
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

                data.inscripcionId = request.inscripcionId;
                data.evaluacion = request.evaluacion;
                data.nota = request.nota;
                data.porcentaje = request.porcentaje;
                data.fecha = request.fecha;

                await _context.SaveChangesAsync();

                return Ok(data);
            }
    }
}