using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{

    [Serializable]
    [Table("token_recupera_usuario", Schema = "usuario")]

    public class TokenRecuperaUsuario
    {
        private Int32 Id;
        private Int32 idUsuario;
        private String Token;
        private String fechaCreado;
        private String fechaVigencia;


        [Key]
        [Column("id")]
        public int id { get => Id; set => Id = value; }
        [Column("id_usuario")]
        public int id_usuario { get => idUsuario; set => idUsuario = value; }
        [Column("token")]
        public string token { get => Token; set => Token = value; }
        [Column("fecha_creado")]
        public string fecha_creado { get => fechaCreado; set => fechaCreado = value; }
        [Column("fecha_vigencia")]
        public string fecha_vigencia { get => fechaVigencia; set => fechaVigencia = value; }



    }
}
