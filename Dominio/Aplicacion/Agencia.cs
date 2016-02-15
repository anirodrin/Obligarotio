using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Aplicacion
{
    public class Agencia
    {
        #region ALTA PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento, string tipoDocumento) 
        {
            return CPasajero.Instancia.AltaPasajero(nombre, apellido, documento, tipoDocumento);

        }
        #endregion

        #region MODIFICACION PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento, int puntaje, int id, string tipoDocumento)
        {
            return CPasajero.Instancia.ModificacionPasajero(nombre, apellido, documento, puntaje, id, tipoDocumento);

        }
        #endregion

        #region ALTA DESTINO
        public bool AltaDestinio(string nombre, string pais, string ciudad, bool esNacional) 
        {
            return CDestino.Instancia.AltaDestino(nombre, pais, ciudad, esNacional);
        }
        #endregion

        #region BAJA DESTINO

        public bool BajaDestino(string nombre) 
        {
            return CDestino.Instancia.BajaDestino(nombre);
        }
        #endregion

        #region DADO UN DESTINO LISTADO DE EXCURSIONES QUE TENGAN ESE DESTINO
        public List<Excursion> ListadoExcursionesPorDestion(string nombre) 
        {
            return CExcursion.Instancia.ListadoExcusrionesQueTienenDestino(nombre);
        }
        #endregion

        #region ALTA EXCURSION NACIONAL
        public Nacional.ErroresAltaExcursion AltaExcursionNacional(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
            int puntos, double costoDiario, List<string> destinos, List<int> cantDias, int descuento) 
        {
            return CExcursion.Instancia.AltaExcursionNacional(codigo, descripcion, fechaInicio, diasTraslado, 
                stockDisponible, puntos, costoDiario, descuento, cantDias, destinos);
        }
        #endregion

        #region ALTA EXCURSION INTRNACIONAL
        public Internacional.ErroresAltaExcursion AltaExcursionNacional(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
            int puntos, double costoDiario, List<string> destinos, List<int> cantDias)
        {
            return CExcursion.Instancia.AltaExcursionInternacional(codigo, descripcion, fechaInicio, diasTraslado,
                stockDisponible, puntos, costoDiario, cantDias, destinos);
        }
        #endregion

        #region LISTADO DESTINOS

        public List<Destino> ListadoDestinosNacionales()
        {
            return CDestino.Instancia.DestinosNacionales();
        }

        public List<Destino> ListadoDestinosInternacionales()
        {
            return CDestino.Instancia.DestinosInternacionales();
        }

        #endregion

        #region LISTADO DE EXCURSIONES CONTRATADAS ENTRE DOS FECHAS
        public List<Excursion> ListadoExcursionesContratadasEntreDosFechas(DateTime fInicio, DateTime fFin)
        {
            return CContrato.Instancia.ListadoExcursionesContratadasEntreDosFechas(fInicio, fFin);
        }
        #endregion
    }
}
