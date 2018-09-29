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
        private String rol;
        private String clave;
        private String correo;
        private String estado;
        private String apellido;
        private String direccion;
        private String telefono;
        private String documento;
        private String foto;
        private String Fecha_nacimiento;
        private String departamento;
        private String ciudad;
        private String sesion;


        [Key]
        [Column("id_usua")]
        public int UserId { get => userId; set => userId = value; }
        [Column("nombre_usua")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("user_name")] 
        public string UserName { get => userName; set => userName = value; }
        [Column("rol_id")]
        public string Rol { get => rol; set => rol = value; }
        [Column("clave")]
        public string Clave { get => clave; set => clave = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("estado")]
        public string Estado { get => estado; set => estado = value; }
        [Column("apellido_usua")]
        public string Apellido { get => apellido; set => apellido = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [Column("telefono")]
        public string Telefono { get => telefono; set => telefono = value; }
        [Column("num_documento")]
        public string Documento { get => documento; set => documento = value; }
        [Column("foto_usua")]
        public string Foto { get => foto; set => foto = value; }
        [Column("fecha_nac")]
        public string fecha_nacimiento { get => Fecha_nacimiento; set => Fecha_nacimiento = value; }
        [Column("dep_nacimiento")]
        public string Departamento { get => departamento; set => departamento = value; }
        [Column("ciu_nacimiento")]
        public string Ciudad { get => ciudad; set => ciudad = value; }
        [Column("sesion")]
        public string Sesion { get => sesion; set => sesion = value; }
    }
}
