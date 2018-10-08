using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Mregistro
{
    [Serializable]
    [Table("anio", Schema = "registro")]
    public class Anio
    {

        private Int32 idAnio;
        private String nombreAnio;

       [Key]
       [Column("id_anio")]
       public int id_anio { get => idAnio; set => idAnio = value; }
       [Column("nombre_anio")]
       public string nombre_anio { get => nombreAnio; set => nombreAnio = value; }

    }
}
