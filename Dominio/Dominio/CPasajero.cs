using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CPasajero
    {
        #region ATRIBUTOS
        public List<Pasajero> pasajeros = new List<Pasajero>();
        #endregion

        #region SINGLETON
        private static CPasajero instancia;

        public static CPasajero Instancia
        {
            get
            {
                if (CPasajero.instancia == null)
                {
                    instancia = new CPasajero();
                }
                return CPasajero.instancia;
            }
        }

        private CPasajero() { }
        #endregion

        #region ALTA PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento)
        {
            bool ret = false;

            Pasajero aux = new Pasajero(nombre, apellido, documento);
            ret = true;

            return ret;
        }

        #endregion

        #region MODIFICACION PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento, int puntaje, int id)
        {
            bool ret = false;
            Pasajero aux = BuscarPasajero(id);
            if (aux != null) 
            {
                aux.Modificacion(nombre, apellido, documento, puntaje);
                ret = true;
            } 
            
            return ret;
        }

        #endregion

        #region BUSCAR PASAJERO

        public Pasajero BuscarPasajero(int id) 
        {
            Pasajero aux = null;
            int i = 0;
            while (i < this.pasajeros.Count && aux != null) 
            {
                if (this.pasajeros[i].Id == id) 
                {
                    aux = this.pasajeros[i];
                }
                i++;
            }
            return aux;
        }

        #endregion
    }
}
