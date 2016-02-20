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
        public void AltaPasajero(string nombre, string apellido, string documento, string tipoDocumento)
        {
            Pasajero aux = new Pasajero(nombre, apellido, documento, tipoDocumento);
            pasajeros.Add(aux);
        }

        #endregion

        #region MODIFICACION PASAJERO
        public void ModificacionPasajero(string nombre, string apellido, string documento, int puntaje, string tipoDocumento, Pasajero aux)
        {

            aux.Modificacion(nombre, apellido, documento, puntaje, tipoDocumento);

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

        #region LISTADO PASAJEROS POR PUNTAJE ORDENADOS
        public List<Pasajero> RankingDePasajerosSegunPuntaje()
        {
            List<Pasajero> listadoAuxiliar = new List<Pasajero>();
            List<Pasajero> listado = new List<Pasajero>();

            listadoAuxiliar.Sort();
            int i = 0;

            while (i < this.pasajeros.Count && i < 9)
            {
                listado.Add(listadoAuxiliar[1]);
                i++;
            }

            return listado;
        }
        #endregion

        #region VALIDACIONES DE ATRIBUTOS

        public bool ValidoNombre(string nombre)
        {
            return Pasajero.ValidoNombre(nombre);
        }

        public bool ValidoApellido(string apellido)
        {
            return Pasajero.ValidoApellido(apellido); ;
        }

        public bool ValidoPuntaje(int puntaje)
        {

            return Pasajero.ValidoPuntaje(puntaje);
        }

        public bool ValidoDocumento(string documento, string tipoDocumento)
        {
           
            return Pasajero.ValidoDocumento(documento, tipoDocumento);
        }

        public bool ValidoTipoDocumento(string tipoDocumento)
        {
            
            return Pasajero.ValidoTipoDocumento(tipoDocumento);
        }

        #endregion
    
    }
}
