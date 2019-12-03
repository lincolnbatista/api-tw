using System.Threading.Tasks;
using API_TW.Models;

namespace API_TW.Interfaces
{
    public interface InterfaceComunidade
    {
          Task <TblComunidade> Post (TblComunidade comunidade);

        Task <TblComunidade> Put (int id , TblComunidade comunidade);

    }
}