using System.Threading.Tasks;
using API_TW.Interfaces;
using API_TW.Models;

namespace API_TW.Repositorio
{
    public class RepositorioComunidade : InterfaceComunidade
    {   
        AgendaContext context =  new AgendaContext();
        public async Task<TblComunidade> Post(TblComunidade comunidade)
        {
           await context.AddAsync(comunidade);
           await context.SaveChangesAsync();
           return comunidade;
        }

        public async Task<TblComunidade> Put(int id, TblComunidade comunidade)
        {
            context.TblComunidade.Update(comunidade);
            context.TblComunidade.Update(comunidade);
            await context.SaveChangesAsync();
            return comunidade;
        }
    }
}