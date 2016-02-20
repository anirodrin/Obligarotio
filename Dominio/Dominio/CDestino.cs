using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CDestino
    {
        #region ATRIBUTOS
        private List<Destino> destinos = new List<Destino>();
        #endregion

        #region SINGLETON
        private static CDestino instancia;

        public static CDestino Instancia
        {
            get
            {
                if (CDestino.instancia == null)
                {
                    instancia = new CDestino();
                }
                return CDestino.instancia;
            }
        }

        private CDestino() { }
        #endregion

        #region ALTA DESTINO

        public void AltaDestino(string nombre, string pais, string ciudad, bool esNacional)
        {
            nombre = nombre.ToUpper();
            pais = pais.ToUpper();
            ciudad = ciudad.ToUpper();
            Destino aux = new Destino(nombre, pais, ciudad, esNacional);
            this.destinos.Add(aux);

        }

        #endregion

        #region BAJA DESTINO
        public void BajaDestino(Destino aux)
        {
            this.destinos.Remove(aux);
        }
        #endregion

        #region BUSQUEDA DE DESTINOS POR NOMBRE

        public Destino BuscarDestinoPorNombre(string nombre)
        {
            Destino aux = null;

            int i = 0;

            while (i < this.destinos.Count && aux == null)
            {
                if (this.destinos[i].Nombre == nombre.ToUpper())
                {
                    aux = this.destinos[i];
                }
                i++;
            }
            return aux;
        }

        #endregion

        #region DESTINOS NACIONALES
        public List<Destino> DestinosNacionales()
        {
            List<Destino> listado = new List<Destino>();

            foreach (Destino unD in this.destinos)
            {
                if (unD.EsNacional)
                {
                    listado.Add(unD);
                }
            }
            return listado;
        }
        #endregion

        #region DESTINOS INTERNACIONALES
        public List<Destino> DestinosInternacionales()
        {
            List<Destino> listado = new List<Destino>();

            foreach (Destino unD in this.destinos)
            {
                if (!unD.EsNacional)
                {
                    listado.Add(unD);
                }
            }          
            return listado;
        }
        #endregion

        #region VALIIDACIONES ALTA DESTINO

        public bool ValidoNombre(string nombre)
        {
            return Destino.ValidoNombre(nombre);
        }

        public bool ValidoPais(string pais)
        {
            return Destino.ValidoPais(pais);
        }

        public bool ValidoCiudad(string ciudad)
        {
            return Destino.ValidoCiudad(ciudad);
        }

        #endregion
    }
}
