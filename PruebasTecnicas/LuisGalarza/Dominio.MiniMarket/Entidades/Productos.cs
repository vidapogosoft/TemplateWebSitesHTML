using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MiniMarket.Entidades
{
    public class Productos
    {
        public int id { get; set; }

        public string Descripcion { get; set; }

        public string Medidas { get; set; }

        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Marcaid { get; set; }
        public int Proveedorid { get; set; }
        public int Categoriaid { get; set; }
         
        public string Marca { get; set; }
        public string Proveedor { get; set; }
        public string Categoria { get; set; }
    }
}
