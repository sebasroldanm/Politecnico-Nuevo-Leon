using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Mlugares
{

    [Serializable]
    [Table("ciudad",Schema = "lugares")]
    public class Ciudad
    {
        Int32 idCiudad;
        String nombreCiudad;
        Int32 idCDepart;

        [Key]
        [Column("id_ciudad")]
        public int id_ciudad { get => idCiudad; set => idCiudad = value; }
        [Column("nombre_ciudad")]
        public string nombre_ciudad { get => nombreCiudad; set => nombreCiudad = value; }
        [Column("id_c_depart")]
        public int id_c_depart { get => idCDepart; set => idCDepart = value; }

    }
}
