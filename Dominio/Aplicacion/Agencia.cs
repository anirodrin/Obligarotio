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
        #region ALTA PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento) 
        {
            return CPasajero.Instancia.AltaPasajero(nombre, apellido, documento);

        }
        #endregion

        #region MODIFICACION PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento, int puntaje, int id)
        {
            return CPasajero.Instancia.ModificacionPasajero(nombre, apellido, documento, puntaje, id);

        }
        #endregion

    }
}
