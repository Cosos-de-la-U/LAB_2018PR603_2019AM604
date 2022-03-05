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
    public class DepartamentoController : ControllerBase
    {
        private readonly DataContext _context;

        //Inyeccion de dependencias
        public DepartamentoController(DataContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> Get()
        {
            return Ok(await _context.Departamentos.ToListAsync());
        }
        
        //Get id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Departamento>>> Get(int id)
        {
            var data= _context.Departamentos.FindAsync(id);
            if (data == null) 
                return BadRequest();
            return Ok(data);
        }
        
        //Post
        [HttpPost]
        public async Task<ActionResult<List<Departamento>>> Post(Departamento data)
        {
            _context.Departamentos.Add(data);
            await _context.SaveChangesAsync();

            return Ok(await _context.Departamentos.ToListAsync());
        }
        
        //Put
        [HttpPut]
        public async Task<ActionResult<List<Departamento>>> Put(Departamento request)
        {
            var data = await _context.Departamentos.FindAsync(request.id);
            
            data.departamento = request.departamento;

            await _context.SaveChangesAsync();

            return Ok(data);
        }


    }
}