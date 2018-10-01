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
        private Int32 id;
        private String idUsuario;
        private String token;
        private String fechaCreado;
        private String fechaVigencia;


        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("id_usuario")]
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
        [Column("fecha_creado")]
        public string FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        [Column("fecha_vigencia")]
        public string FechaVigencia { get => fechaVigencia; set => fechaVigencia = value; }



    }
}
