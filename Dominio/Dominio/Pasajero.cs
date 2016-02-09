using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasajero
    {
        #region ATRIBUTOS
        private int id;
        public static int ultId = 0;
        public string nombre;
        public string apellido;
        private string documento;
        public int puntajeAcumulado;
        #endregion

        #region PROPIEDADES
        public int Id
        {
            get { return this.id; }
        }

        public string Documento
        {
            get { return this.documento; }
        }
        #endregion

        #region CONSTRUCTOR
        public Pasajero(string nombre, string apellido, string documento)
        {
            this.id = ++Pasajero.ultId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.puntajeAcumulado = 0;
        }
        #endregion

        #region VALIDACIONES DE ATRIBUTOS

        public static bool ValidoNombre(string nombre)
        {
            return !string.IsNullOrEmpty(nombre);
        }

        public static bool ValidoApellido(string apellido)
        {
            return !string.IsNullOrEmpty(apellido);
        }

        public static bool ValidoPuntaje(int puntaje)
        {

            bool ret = (puntaje >= 0) ? true : false;

            return ret;
        }

        public static bool ValidoCi(string ci) 
        {
            return !string.IsNullOrEmpty(ci);
        }

        #endregion

        #region MODIFICACION PASAJERO

        public void Modificacion(string nombre, string apellido, string documento, int puntaje)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.puntajeAcumulado = puntaje;
        }

        #endregion
    }
}
