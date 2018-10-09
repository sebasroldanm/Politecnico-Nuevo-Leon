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
    [Table("departamento", Schema ="lugares")]
    public class Departamento
    {
        Int32 idDep;
        String nomDep;

        [Key]
        [Column("id_dep")]
        public int id_dep { get => idDep; set => idDep = value; }
        [Column("nom_dep")]
        public string nom_dep { get => nomDep; set => nomDep = value; }
        
    }
}
