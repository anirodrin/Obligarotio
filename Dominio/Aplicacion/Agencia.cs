using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Aplicacion
{
    public class Agencia
    {
        public bool AltaPasajero(string nombre, string apellido, string documento) 
        {
            bool ret = CPasajero.Instancia.AltaPasajero(nombre, apellido, documento);

            return ret;
            
        }
    }
}
