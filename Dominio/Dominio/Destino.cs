using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Destino
    {
        #region ATRIBUTOS

        private string nombre;
        private string pais;
        private string ciudad;
        private bool esNacional;

        #endregion

        #region PROPIEDADES

        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Ciudad
        {
            get { return this.ciudad; }
        }
        public string Pais
        {
            get { return this.pais; }
        }

        public bool EsNacional
        {
            get { return this.esNacional; }
        }

        #endregion

        #region CONSTRUCTOR

        public Destino(string nombre, string pais, string ciudad, bool esNacional)
        {
            this.nombre = nombre;
            this.pais = pais;
            this.ciudad = ciudad;
            this.esNacional = esNacional;
        }

        #endregion

        #region VALIIDACIONES ALTA DESTINO

        public static bool ValidoNombre(string nombre)
        {
            return !string.IsNullOrEmpty(nombre);
        }

        public static bool ValidoPais(string pais)
        {
            return !string.IsNullOrEmpty(pais);
        }

        public static bool ValidoCiudad(string ciudad)
        {
            return !string.IsNullOrEmpty(ciudad);
        }

        #endregion

        #region OVERRIDE METODO EQUALS
        public override bool Equals(object obj)
        {
            bool ret = false;
            Destino aux = obj as Destino;
            if (aux != null)
            {
                ret = this.nombre == aux.nombre;
            }
            return ret;
        }

        #endregion

    }
}
