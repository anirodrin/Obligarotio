using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Pasajero
    {
        #region ATRIBUTOS
        private int id;
        public static int ultId = 0;
        public string nombre;
        public string apellido;
        public string documento;
        public int puntajeAcumulado;
        #endregion

        public int Id
        {
            get { return this.id; }
        }

        #region CONSTRUCTOR
        public Pasajero(string nombre, string apellido, string documento) 
        {
            this.id =++ Pasajero.ultId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.puntajeAcumulado = 0;
        }
        #endregion

        #region MODIFICACION PASAJERO

        public bool Modificacion(string nombre, string apellido, string documento, int puntaje) 
        {
            bool ret = false;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.puntajeAcumulado = puntaje;
            ret = true;

            return ret;
        }

        #endregion
    }
}
