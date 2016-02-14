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

        public bool AltaDestino(string nombre, string pais, string ciudad, bool esNacional) 
        {
            bool ret = false;
            if (Destino.ValidoNombre(nombre)) 
            {
                if (Destino.ValidoPais(pais)) 
                {
                    if (Destino.ValidoCiudad(ciudad)) 
                    {
                        Destino aux = BuscarDestinoPorNombre(nombre);
                        if (aux == null) 
                        {
                            nombre = nombre.ToUpper();
                            pais = pais.ToUpper();
                            ciudad = ciudad.ToUpper();
                            aux = new Destino(nombre, pais, ciudad, esNacional);
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        #region BAJA DESTINO
        public bool BajaDestino(string nombre)
        {
            bool ret = false;
            Destino aux = BuscarDestinoPorNombre(nombre);
            if (aux != null) 
            {
                if (!CExcursion.Instancia.TieneDestino(aux)) 
                {
                    this.destinos.Remove(aux);
                    ret = false;
                }
            }
            return ret;
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

    }
}
