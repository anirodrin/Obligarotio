using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CExcursion
    {
        #region ATRIBUTOS
        public List<Excursion> excursiones = new List<Excursion>();
        #endregion

        #region SINGLETON
        private static CExcursion instancia;

        public static CExcursion Instancia
        {
            get
            {
                if (CExcursion.instancia == null)
                {
                    instancia = new CExcursion();
                }
                return CExcursion.instancia;
            }
        }

        private CExcursion() { }
        #endregion

        #region TIENE DESTINO
        public bool TieneDestino(Destino destino)
        {
            bool ret = false;
            int i = 0;

            while (i < this.excursiones.Count && !ret)
            {
                if (this.excursiones[i].TieneDestino(destino))
                {
                    ret = true;
                }
            }

            return ret;

        }
        #endregion

        #region LISTADO EXCURSIONES QUE TENGAN DETERMINADO DESTINO
        public List<Excursion> ListadoExcusrionesQueTienenDestino(string nombre)
        {
            List<Excursion> listado = new List<Excursion>();
            Destino aux = CDestino.Instancia.BuscarDestinoPorNombre(nombre);

            if (aux != null)
            {
                foreach (Excursion unaE in this.excursiones)
                {
                    if (unaE.TieneDestino(aux))
                    {
                        listado.Add(unaE);
                    }
                }
            }
            return listado;
        }
        #endregion

        #region ALTA EXCURSION NACIONAL
        public Nacional.ErroresAltaExcursion AltaExcursionNacional(string codigo, string descripcion,
            DateTime fechaInicio, int diasTraslado, int stockDisponible,int puntos, double costoDiario, int descuento,
            List<int> cantDias, List<string> destino)
        {
            Nacional.ErroresAltaExcursion ret = Nacional.ErroresAltaExcursion.OK;
            if (!Excursion.ValidoCodigo(codigo)) 
            {
                ret = Nacional.ErroresAltaExcursion.Cod_Invalido;
            }
            else if (!Excursion.ValidoDescripcion(descripcion)) 
            {
                ret = Nacional.ErroresAltaExcursion.Desc_Vaicia;
            }
            else if (!Excursion.ValidoFechaInicio(fechaInicio)) 
            {
                ret = Nacional.ErroresAltaExcursion.Fi_Invalida;
            }
            else if (!Excursion.ValidoDiasTraslado(diasTraslado)) 
            {
                ret = Nacional.ErroresAltaExcursion.DiasTraslado_Invalido;
            }
            else if (!Excursion.ValidoStockDisponible(stockDisponible)) 
            {
                ret = Nacional.ErroresAltaExcursion.Stock_Invalido;
            }
            else if (!Excursion.ValidoPuntos(puntos)) 
            {
                ret = Nacional.ErroresAltaExcursion.Puntos_Invalido;
            }
            else if (!Excursion.ValidoCostoDiario(costoDiario))
            {
                ret = Nacional.ErroresAltaExcursion.Costo_Invalido;
            }
            else if (!Nacional.ValidoDescuento(descuento)) 
            {
                ret = Nacional.ErroresAltaExcursion.Descuento_Invalido;
            }
            else
            {
                Excursion aux = BuscarExcursion(codigo);
                if (aux == null)
                {
                    aux = new Nacional(codigo, descripcion, fechaInicio, diasTraslado, stockDisponible,
                        puntos, costoDiario, descuento);
                    
                }
            }
            return ret;
        }
        #endregion

        #region ALTA EXCURSION INTERNACIONAL
        public Internacional.ErroresAltaExcursion AltaExcursionInternacional(string codigo, string descripcion,
            DateTime fechaInicio, int diasTraslado, int stockDisponible,int puntos, double costoDiario,
            List<int> cantDias, List<string> destinos)
        {
            Internacional.ErroresAltaExcursion ret = Internacional.ErroresAltaExcursion.OK;
            if (!Excursion.ValidoCodigo(codigo))
            {
                ret = Internacional.ErroresAltaExcursion.Cod_Invalido;
            }
            else if (!Excursion.ValidoDescripcion(descripcion))
            {
                ret = Internacional.ErroresAltaExcursion.Desc_Vaicia;
            }
            else if (!Excursion.ValidoFechaInicio(fechaInicio))
            {
                ret = Internacional.ErroresAltaExcursion.Fi_Invalida;
            }
            else if (!Excursion.ValidoDiasTraslado(diasTraslado))
            {
                ret = Internacional.ErroresAltaExcursion.DiasTraslado_Invalido;
            }
            else if (!Excursion.ValidoStockDisponible(stockDisponible))
            {
                ret = Internacional.ErroresAltaExcursion.Stock_Invalido;
            }
            else if (!Excursion.ValidoPuntos(puntos))
            {
                ret = Internacional.ErroresAltaExcursion.Puntos_Invalido;
            }
            else if (!Excursion.ValidoCostoDiario(costoDiario))
            {
                ret = Internacional.ErroresAltaExcursion.Costo_Invalido;
            }
            else
            {
                Excursion aux = BuscarExcursion(codigo);
                if (aux == null)
                {
                    aux = new Internacional(codigo, descripcion, fechaInicio, diasTraslado, stockDisponible,
                        puntos, costoDiario);
                }
            }
            return ret;
        }
        #endregion

        #region BUSCAR EXCURSION POR CODIGO

        public Excursion BuscarExcursion(string codigo) 
        {
            Excursion aux = null;
            int i = 0;

            while (i < this.excursiones.Count && aux == null) 
            {
                if (this.excursiones[i].Codigo == codigo) 
                {
                    aux = this.excursiones[i];
                }
                i++;
            }

            return aux;
        }

        #endregion

        #region AGREGAR DESTINOS A EXCURSION

        public void AgregarDestinos(List<int> cantDias, List<string> destinos, Excursion aux)
        {
            if (aux != null)
            {
                for (int i = 0; i < destinos.Count; i++)
                {
                    Destino destino = CDestino.Instancia.BuscarDestinoPorNombre(destinos[i]);
                    if (destino != null)
                    {
                        aux.AgregarDestinos(cantDias[i], destino);
                    }
                }
            }
        }
        #endregion

    }
}
