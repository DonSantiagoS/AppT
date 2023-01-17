using AppT.Models;

namespace AppT.Services
{
    public interface ServicioApi
    {
        Task<List<Register>> Lista();
        Task<Register> Obtener(String TitleRegister);
    }
}
