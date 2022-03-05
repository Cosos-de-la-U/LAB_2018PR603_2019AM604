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
    public class MateriaController : ControllerBase
    {
            private readonly DataContext _context;

            //Inyeccion de dependencias
            public MateriaController(DataContext context)
            {
                _context = context;
            }

            //Get
            [HttpGet]
            public async Task<ActionResult<List<Materia>>> Get()
            {
                return Ok(await _context.Materias.ToListAsync());
            }
        
            //Get id
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Materia>>> Get(int id)
            {
                var data= _context.Materias.FindAsync(id);
                if (data == null) 
                    return BadRequest();
                return Ok(data);
            }
        
            //Post
            [HttpPost]
            public async Task<ActionResult<List<Materia>>> Post(Materia data)
            {
                _context.Materias.Add(data);
                await _context.SaveChangesAsync();

                return Ok(await _context.Materias.ToListAsync());
            }
        
            //Put
            [HttpPut]
            public async Task<ActionResult<List<Materia>>> Put(Materia request)
            {
                var data = await _context.Materias.FindAsync(request.id);

                data.facultadId = request.facultadId;
                data.materia = request.materia;
                data.unidades_valorativas = request.unidades_valorativas;
                data.estado = request.estado;

                await _context.SaveChangesAsync();

                return Ok(data);
            }
    }
}