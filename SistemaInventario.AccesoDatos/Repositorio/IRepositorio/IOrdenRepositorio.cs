using SistemaInventario.Modelos;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IOrdenRepositorio : IRepositorio<Orden>
    {
        void Actualizar(Orden orden); 
        void ActualizarEstado(int id, string ordenEstado, string pagoEstado);
        void ActualizarPagoStripeId(int id, string sessionId, string transaccionId);
    }
}
