﻿using SistemaInventario.Modelos;
using SistemaInventarioV7.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IBodegaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Bodega bodega)
        {

          var bodegaBD = _db.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
          if(bodegaBD == null)
            {
    
            }
        }
    }
}