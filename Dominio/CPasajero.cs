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

            if (Pasajero.ValidoCi(documento))
            {
                if (Pasajero.ValidoNombre(nombre))
                {
                    if (Pasajero.ValidoApellido(apellido))
                    {
                        Pasajero aux = BuscarPasajeroPorDoc(documento);
                        if (aux == null)
                        {
                            ret = true;
                            aux = new Pasajero(nombre, apellido, documento);
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        #region MODIFICACION PASAJERO
        public bool ModificacionPasajero(string nombre, string apellido, string documento, int puntaje, int id)
        {
            bool ret = false;

            if (Pasajero.ValidoCi(documento))
            {
                if (Pasajero.ValidoNombre(nombre))
                {
                    if (Pasajero.ValidoApellido(apellido))
                    {
                        if (Pasajero.ValidoPuntaje(puntaje))
                        {
                            Pasajero aux = BuscarPasajeroPorId(id);
                            if (aux != null)
                            {
                                aux.Modificacion(nombre, apellido, documento, puntaje);
                                ret = true;
                            }
                        }
                    }
                }

            }

            return ret;
        }

        #endregion

        #region BUSCAR PASAJERO POR ID

        public Pasajero BuscarPasajeroPorId(int id)
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

        #region BUSCAR PASAJERO POR DOCUMENTO

        public Pasajero BuscarPasajeroPorDoc(string doc)
        {
            Pasajero aux = null;
            int i = 0;
            while (i < this.pasajeros.Count && aux != null)
            {
                if (this.pasajeros[i].Documento == doc)
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
