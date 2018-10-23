using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("usuario", Schema = "usuario")]
    public class Usuario
    {

        private Int32 userId;
        private String nombre;
        private String userName;
        private Int32 rol;
        private String Clave;
        private String Correo;
        private Boolean Estado;
        private String apellido;
        private String Direccion;
        private String Telefono;
        private Int32 documento;
        private String foto;
        private String Fecha_nacimiento;
        private Int32 departamento;
        private Int32 ciudad;
        private String sesion1;
        private String ultimaModificacion;
        private Int32 stateT;


        [Key]
        [Column("id_usua")]
        public int id_usua { get => userId; set => userId = value; }
        [Column("nombre_usua")]
        public string nombre_usua { get => nombre; set => nombre = value; }
        [Column("user_name")] 
        public string user_name { get => userName; set => userName = value; }
        [Column("rol_id")]
        public int rol_id { get => rol; set => rol = value; }
        [Column("clave")]
        public string clave { get => Clave; set => Clave = value; }
        [Column("correo")]
        public string correo { get => Correo; set => Correo = value; }
        [Column("estado")]
        public Boolean estado { get => Estado; set => Estado = value; }
        [Column("apellido_usua")]
        public string apellido_usua { get => apellido; set => apellido = value; }
        [Column("direccion")]
        public string direccion { get => Direccion; set => Direccion = value; }
        [Column("telefono")]
        public string telefono { get => Telefono; set => Telefono = value; }
        [Column("num_documento")]
        public int num_documento { get => documento; set => documento = value; }
        [Column("foto_usua")]
        public string foto_usua { get => foto; set => foto = value; }
        [Column("fecha_nac")]
        public string fecha_nac { get => Fecha_nacimiento; set => Fecha_nacimiento = value; }
        [Column("dep_nacimiento")]
        public int dep_nacimiento { get => departamento; set => departamento = value; }
        [Column("ciu_nacimiento")]
        public int ciu_nacimiento { get => ciudad; set => ciudad = value; }
        [Column("sesion")]
        public string sesion { get => sesion1; set => sesion1 = value; }
        [Column("ultima_modificacion")]
        public string ultima_modificacion { get => ultimaModificacion; set => ultimaModificacion = value; }
        [Column("state_t")]
        public int state_t { get => stateT; set => stateT = value; }



    }
}
