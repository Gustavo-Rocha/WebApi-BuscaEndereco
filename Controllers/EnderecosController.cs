using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuscaEndereco;
using BuscaEndereco.Models;
using System.ComponentModel.DataAnnotations;

namespace BuscaEndereco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EnderecosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> Get()
        {
            //Endereco endereco = new Endereco();
            //endereco.Cep = 03728050;
            //endereco.Rua = "ana matos";
            //endereco.Numero = 36;
            //endereco.Bairro = "vila silvia";
            //endereco.Cidade = "sao paulo";
            //endereco.Estado = "sao paulo";

            //_context.Enderecos.Add(endereco);
            //await _context.SaveChangesAsync();
            var retorno = _context.Enderecos.ToListAsync();

            if(retorno==null)
            {
                return NotFound();
            }
            else
            {
                return await retorno;
            }
            
        }

        // GET: api/Enderecos/5
        [HttpGet("{cep}")]
        public async Task<ActionResult<Endereco>> Get(string cep)
        {
            var endereco = await _context.Enderecos.FindAsync(cep);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Endereco endereco)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.Cep))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Enderecos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Endereco>> Post(Endereco endereco)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //[StringLength(8, MinimumLength = 8)] string cep
           
                _context.Enderecos.Add(endereco);
                await _context.SaveChangesAsync();

                //  return CreatedAtAction("GetEndereco", new { id = endereco.Cep }, endereco);
                return CreatedAtAction(nameof(Get), new { id = endereco.Cep }, endereco);
                

            
            //return StatusCode(406);


        }

        // DELETE: api/Enderecos/5
        [HttpDelete("{cep}")]
        public async Task<ActionResult<Endereco>> Delete(string cep)
        {
            var endereco = await _context.Enderecos.FindAsync(cep);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        private bool EnderecoExists(string cep)
        {
            return _context.Enderecos.Any(e => e.Cep == cep);
        }
    }
}
