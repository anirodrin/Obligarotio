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
        public bool AltaPasajero(string nombre, string apellido, string documento, string tipoDocumento)
        {
            bool ret = false;
            if (Pasajero.ValidoTipoDocumento(tipoDocumento))
            {
                if (Pasajero.ValidoDocumento(documento, tipoDocumento))
                {
                    if (Pasajero.ValidoNombre(nombre))
                    {
                        if (Pasajero.ValidoApellido(apellido))
                        {
                            Pasajero aux = BuscarPasajeroPorDocYTipo(documento, tipoDocumento);
                            if (aux == null)
                            {
                                ret = true;
                                aux = new Pasajero(nombre, apellido, documento, tipoDocumento);
                            }
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        #region MODIFICACION PASAJERO
        public bool ModificacionPasajero(string nombre, string apellido, string documento, int puntaje, int id, string tipoDocumento)
        {
            bool ret = false;
            if (Pasajero.ValidoTipoDocumento(tipoDocumento))
            {
                if (Pasajero.ValidoDocumento(documento, tipoDocumento))
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
                                    aux = BuscarPasajeroPorDocYTipo(documento, tipoDocumento);
                                    if (aux != null)
                                    {
                                        if (aux.Id == id)
                                        {
                                            aux.Modificacion(nombre, apellido, documento, puntaje, tipoDocumento);
                                            ret = true;
                                        }
                                    }
                                    else 
                                    {
                                        aux.Modificacion(nombre, apellido, documento, puntaje, tipoDocumento);
                                        ret = true;
                                    }
                                }
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

        #region BUSCAR PASAJERO POR DOCUMENTO Y TIPO DE DOCUMENTO

        public Pasajero BuscarPasajeroPorDocYTipo(string doc, string tipoDoc)
        {
            Pasajero aux = null;
            int i = 0;
            while (i < this.pasajeros.Count && aux != null)
            {
                if (this.pasajeros[i].Documento == doc && this.pasajeros[i].tipoDocumento == tipoDoc)
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
