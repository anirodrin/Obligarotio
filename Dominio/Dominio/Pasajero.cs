using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasajero: IComparable<Pasajero>
    {
        #region ATRIBUTOS
        private int id;
        public static int ultId = 0;
        public string nombre;
        public string apellido;
        public string tipoDocumento;
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
        public Pasajero(string nombre, string apellido, string documento, string tipoDocumento)
        {
            this.id = ++Pasajero.ultId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
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

        public static bool ValidoDocumento(string documento, string tipoDocumento) 
        {
            bool ret = !string.IsNullOrEmpty(documento);
            if (ret) 
            {
                if (tipoDocumento == "CI") 
                {
                    ret = Regex.IsMatch(documento, "^[1-9]{1}[.][0-9]{3}[.][0-9]{3}[-][0-9]{1}$");
                    if (!ret) 
                    {
                        ret = Regex.IsMatch(documento, "^[0-9]{3}.[0-9]{3}-[0-9]{1}$");
                    }

                }
            }

            return ret;
        }

        public static bool ValidoTipoDocumento(string tipoDocumento)
        {
            bool ret = !string.IsNullOrEmpty(tipoDocumento);
            if (ret) 
            {
                ret = (tipoDocumento == "CI" || tipoDocumento == "PA") ? true : false;
            }
            return ret;
        }

        #endregion

        #region MODIFICACION PASAJERO

        public void Modificacion(string nombre, string apellido, string documento, int puntaje, string tipoDocumento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.puntajeAcumulado = puntaje;
            this.tipoDocumento = tipoDocumento;
        }

        #endregion

        #region IMPLEMETACION DE METODO COMPARE TO DE PUNTAJES, APELLIDO Y NOMBRE
        public int CompareTo(Pasajero otro)
        {
            int ret = 0;
            if (otro != null) 
            {
                ret = this.puntajeAcumulado.CompareTo(otro.puntajeAcumulado);

                if (ret == 0) 
                {
                    ret = this.apellido.CompareTo(otro.apellido);
                    if (ret == 0) 
                    {
                        ret = this.nombre.CompareTo(otro.nombre);
                    }
                }
            }
            return ret;
        }
        #endregion

    }
}
