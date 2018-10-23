using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("usuario", Schema = "estudianteacudiente")]
    public class ListaAcudiente
    {
        private Int32 IdEstudiante;
        private String Nomestudiante;
        private String Apeestudiante;
        private String Userestudiante;
        private String Claveestudiante;
        private String Telefonoestudiante;
        private String Fotoestudiante;
        private Int32 Docestudiante;
        private Int32 Id_es;
        private Int32 Idacudiente;
        private String Nomacudiente;
        private String Apeacudiente;
        private String Useracudiente;
        private String Claveacudiente;
        private String Telefonoacudiente;
        private String Fotoacudiente;
        private Int32 Docacudiente;
        private Int32 Id_ac;
        
        
        
        

        [Key]
        [Column("idestudiante")]
        public int idestudiante { get => IdEstudiante; set => IdEstudiante = value; }
        [Column("nomestudiante")]
        public string nomestudiante { get => Nomestudiante; set => Nomestudiante = value; }
        [Column("apeestudiante")]
        public string apeestudiante { get => Apeestudiante; set => Apeestudiante = value; }
        [Column("userestudiante")]
        public string userestudiante { get => Userestudiante; set => Userestudiante = value; }
        [Column("claveestudiante")]
        public string claveestudiante { get => Claveestudiante; set => Claveestudiante = value; }
        [Column("telefonoestudiante")]
        public string telefonoestudiante { get => Telefonoestudiante; set => Telefonoestudiante = value; }
        [Column("fotoestudiante")]
        public string fotoestudiante { get => Fotoestudiante; set => Fotoestudiante = value; }
        [Column("docestudiante")]
        public int docestudiante { get => Docestudiante; set => Docestudiante = value; }
        [Column("id_es")]
        public int id_es { get => Id_es; set => Id_es = value; }
        [Column("idacudiente")]
        public int idacudiente { get => Idacudiente; set => Idacudiente = value; }
        [Column("nomacudiente")]
        public string nomacudiente { get => Nomacudiente; set => Nomacudiente = value; }
        [Column("apeacudiente")]
        public string apeacudiente { get => Apeacudiente; set => Apeacudiente = value; }
        [Column("useracudiente")]
        public string useracudiente { get => Useracudiente; set => Useracudiente = value; }
        [Column("claveacudiente")]
        public string claveacudiente { get => Claveacudiente; set => Claveacudiente = value; }
        [Column("telefonoacudiente")]
        public string telefonoacudiente { get => Telefonoacudiente; set => Telefonoacudiente = value; }
        [Column("fotoacudiente")]
        public string fotoacudiente { get => Fotoacudiente; set => Fotoacudiente = value; }
        [Column("docacudiente")]
        public int docacudiente { get => Docacudiente; set => Docacudiente = value; }
        [Column("id_ac")]
        public int id_ac { get => Id_ac; set => Id_ac = value; }

    }
}
