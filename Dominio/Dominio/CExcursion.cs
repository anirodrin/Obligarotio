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
        public List<Excursion> ListadoExcusrionesQueTienenDestino(Destino aux)
        {
            List<Excursion> listado = new List<Excursion>();
            foreach (Excursion unaE in this.excursiones)
            {
                if (unaE.TieneDestino(aux))
                {
                    listado.Add(unaE);
                }
            }
            return listado;
        }
        #endregion

        #region CREAR EXCURSION NACIONAL
        public Excursion CrearExcursionInternacional(string codigo, string descripcion,
            DateTime fechaInicio, int diasTraslado, int stockDisponible, int puntos, double costoDiario, int descuento,
            List<int> cantDias, List<string> destinos)
        {
             return new Nacional(codigo, descripcion, fechaInicio, diasTraslado, stockDisponible,
                 puntos, costoDiario, descuento);
        }
        #endregion

        #region CREAR EXCURSION INTERNACIONAL
        public Excursion CrearExcursionInternacional(string codigo, string descripcion,
            DateTime fechaInicio, int diasTraslado, int stockDisponible, int puntos, double costoDiario,
            List<int> cantDias, List<string> destinos)
        {
            return new Internacional(codigo, descripcion, fechaInicio, diasTraslado, stockDisponible,
                 puntos, costoDiario);

        }
        #endregion

        #region ALTA EXCURSION

        public void AltaExcursion(Excursion aux) 
        {
            this.excursiones.Add(aux);
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

        public bool AgregarDestinos(int cantDias, Destino destino, Excursion aux)
        {

            return aux.AgregarDestinos(cantDias, destino);

        }
        #endregion

        #region DESTINOS POR EXCURSION

        public List<Destino> DestinosPorExcursion(Excursion aux) 
        {
            List<Destino> destinos = new List<Destino>();
            if (aux != null) 
            {
                List<DestinoExcursion> destinoExcusrion = aux.Destinos;
                foreach(DestinoExcursion unD in destinoExcusrion)
                {
                    destinos.Add(unD.Destino);
                }
            }
            return destinos;
        }

        #endregion

        #region VALIDACIONES ALTA EXCURSION
        public bool ValidoCodigo(string codigo)
        {
            return Excursion.ValidoCodigo(codigo);
        }

        public bool ValidoDescripcion(string descripcion)
        {
            return Excursion.ValidoDescripcion(descripcion);
        }

        public bool ValidoFechaInicio(DateTime fechaInicio)
        {
            return Excursion.ValidoFechaInicio(fechaInicio);
        }

        public bool ValidoDiasTraslado(int diasTraslado)
        {
            return Excursion.ValidoDiasTraslado(diasTraslado);
        }

        public bool ValidoStockDisponible(int stockDisponible)
        {
            return Excursion.ValidoStockDisponible(stockDisponible);
        }

        public bool ValidoPuntos(int puntos)
        {
            return puntos > 0;
        }

        public bool ValidoCostoDiario(double costoDiario)
        {
            return Excursion.ValidoCostoDiario(costoDiario);
        }

        public bool ValidoCantDias(int dias)
        {
            return Excursion.ValidoCantDias(dias);
        }

        public bool ValidoDescuento(int descuento)
        {
            return Nacional.ValidoDescuento(descuento);
        }
        #endregion
   
    }
}
