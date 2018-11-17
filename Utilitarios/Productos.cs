using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
   public  class Productos
    {
        private String imagen;
        private int codigoProducto;
        private String descripcion;
        private String categoria;
        private double precio;
        private String nombreSubsede;

        public string Imagen { get => imagen; set => imagen = value; }
        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }
        public string NombreSubsede { get => nombreSubsede; set => nombreSubsede = value; }
    }
}
