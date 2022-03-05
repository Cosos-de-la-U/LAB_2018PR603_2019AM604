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
    public class FacultadController : ControllerBase
    {
            private readonly DataContext _context;

            //Inyeccion de dependencias
            public FacultadController(DataContext context)
            {
                _context = context;
            }

            //Get
            [HttpGet]
            public async Task<ActionResult<List<Facultad>>> Get()
            {
                return Ok(await _context.Facultades.ToListAsync());
            }
        
            //Get id
            [HttpGet("{id}")]
            public async Task<ActionResult<List<Facultad>>> Get(int id)
            {
                var data= _context.Facultades.FindAsync(id);
                if (data == null) 
                    return BadRequest();
                return Ok(data);
            }
        
            //Post
            [HttpPost]
            public async Task<ActionResult<List<Facultad>>> Post(Facultad data)
            {
                _context.Facultades.Add(data);
                await _context.SaveChangesAsync();

                return Ok(await _context.Facultades.ToListAsync());
            }
        
            //Put
            [HttpPut]
            public async Task<ActionResult<List<Facultad>>> Put(Facultad request)
            {
                var data = await _context.Facultades.FindAsync(request.id);

                data.facultad= request.facultad;

                await _context.SaveChangesAsync();

                return Ok(data);
            }
    }
}