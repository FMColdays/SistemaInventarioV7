using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventarioV7.AccesoDatos.Data;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Marca marca)
        {
            var MarcaDB = _db.Marcas.FirstOrDefault(x => x.Id == marca.Id);
            if (MarcaDB != null)
            {
                MarcaDB.Nombre = marca.Nombre;
                MarcaDB.Descripcion = marca.Descripcion;
                MarcaDB.Estado = marca.Estado;
                _db.SaveChanges();
            }
        }
    }
}
