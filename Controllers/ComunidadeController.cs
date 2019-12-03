using System.Threading.Tasks;
using API_TW.Models;
using API_TW.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TW.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
    public class ComunidadeController : ControllerBase
    {


        AgendaContext context = new AgendaContext();
        RepositorioComunidade repositorio = new RepositorioComunidade();

        [HttpPost]
        public async Task<ActionResult<TblComunidade>> Post(TblComunidade comunidade)
        {
            try
            {
                 return await repositorio.Post(comunidade);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

           
        
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> put(TblComunidade comunidade)
       {
            
            if (comunidade == null)
            {
                return NotFound();
            }
            comunidade.NomeComunidade = comunidade.NomeComunidade;
            comunidade.NomeResponsavel = comunidade.NomeResponsavel;
            context.TblComunidade.Update(comunidade);
            await context.SaveChangesAsync();
            

            return NoContent();

           
       }


        
    }
}