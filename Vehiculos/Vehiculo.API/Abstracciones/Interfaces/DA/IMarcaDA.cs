using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IMarcaDA
    {
        Task<IEnumerable<Marca>> Obtener();
    }
}
