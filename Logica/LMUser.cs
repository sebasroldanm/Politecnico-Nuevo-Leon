using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LMUser
    {
        public void insertarUserMapeo(Usuario text)
        {
            DMUser dao = new DMUser();
            dao.insertarUserMapeo(text);
        }

    }
}
