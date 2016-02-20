using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Collections;

namespace Aplicacion
{
    public class Agencia
    {
        #region ALTA PASAJERO
        public bool AltaPasajero(string nombre, string apellido, string documento, string tipoDocumento)
        {
            bool ret = false;
            if (CPasajero.Instancia.ValidoTipoDocumento(tipoDocumento))
            {
                if (CPasajero.Instancia.ValidoDocumento(documento, tipoDocumento))
                {
                    if (CPasajero.Instancia.ValidoNombre(nombre))
                    {
                        if (CPasajero.Instancia.ValidoApellido(apellido))
                        {
                            Pasajero aux = CPasajero.Instancia.BuscarPasajeroPorDocYTipo(documento, tipoDocumento);
                            if (aux == null)
                            {
                                ret = true;
                                CPasajero.Instancia.AltaPasajero(nombre, apellido, documento, tipoDocumento);
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
            if (CPasajero.Instancia.ValidoTipoDocumento(tipoDocumento))
            {
                if (CPasajero.Instancia.ValidoDocumento(documento, tipoDocumento))
                {
                    if (CPasajero.Instancia.ValidoNombre(nombre))
                    {
                        if (CPasajero.Instancia.ValidoApellido(apellido))
                        {
                            if (CPasajero.Instancia.ValidoPuntaje(puntaje))
                            {
                                Pasajero aux = CPasajero.Instancia.BuscarPasajeroPorId(id);
                                if (aux != null)
                                {
                                    aux = CPasajero.Instancia.BuscarPasajeroPorDocYTipo(documento, tipoDocumento);
                                    if (aux != null)
                                    {
                                        if (aux.Id == id)
                                        {
                                            CPasajero.Instancia.ModificacionPasajero(nombre, apellido, documento, puntaje, tipoDocumento, aux);
                                            ret = true;
                                        }
                                    }
                                    else
                                    {
                                        CPasajero.Instancia.ModificacionPasajero(nombre, apellido, documento, puntaje, tipoDocumento, aux);
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

        #region ALTA DESTINO
        public bool AltaDestinio(string nombre, string pais, string ciudad, bool esNacional)
        {
            bool ret = false;
            if (CDestino.Instancia.ValidoNombre(nombre))
            {
                if (CDestino.Instancia.ValidoPais(pais))
                {
                    if (CDestino.Instancia.ValidoCiudad(ciudad))
                    {
                        Destino aux = CDestino.Instancia.BuscarDestinoPorNombre(nombre);
                        if (aux == null)
                        {
                            CDestino.Instancia.AltaDestino(nombre, pais, ciudad, esNacional);
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
            Destino aux = CDestino.Instancia.BuscarDestinoPorNombre(nombre);
            if (aux != null)
            {
                if (!CExcursion.Instancia.TieneDestino(aux))
                {
                    CDestino.Instancia.BajaDestino(aux);
                    ret = true;
                }
            }
            return ret;

        }
        #endregion

        #region DADO UN DESTINO LISTADO DE EXCURSIONES QUE TENGAN ESE DESTINO
        public List<Excursion> ListadoExcursionesPorDestion(string nombre)
        {
            List<Excursion> listado = new List<Excursion>();
            Destino aux = CDestino.Instancia.BuscarDestinoPorNombre(nombre);

            if (aux != null)
            {
                listado = CExcursion.Instancia.ListadoExcusrionesQueTienenDestino(aux);
            }
            return listado;
        }
        #endregion

        #region ALTA EXCURSION NACIONAL
        public Nacional.ErroresAltaExcursion AltaExcursionNacional(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
            int puntos, double costoDiario, List<string> destinos, List<int> cantDias, int descuento)
        {
            Nacional.ErroresAltaExcursion ret = Nacional.ErroresAltaExcursion.OK;
            if (!CExcursion.Instancia.ValidoCodigo(codigo))
            {
                ret = Nacional.ErroresAltaExcursion.Cod_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoDescripcion(descripcion))
            {
                ret = Nacional.ErroresAltaExcursion.Desc_Vaicia;
            }
            else if (!CExcursion.Instancia.ValidoFechaInicio(fechaInicio))
            {
                ret = Nacional.ErroresAltaExcursion.Fi_Invalida;
            }
            else if (!CExcursion.Instancia.ValidoDiasTraslado(diasTraslado))
            {
                ret = Nacional.ErroresAltaExcursion.DiasTraslado_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoStockDisponible(stockDisponible))
            {
                ret = Nacional.ErroresAltaExcursion.Stock_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoPuntos(puntos))
            {
                ret = Nacional.ErroresAltaExcursion.Puntos_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoCostoDiario(costoDiario))
            {
                ret = Nacional.ErroresAltaExcursion.Costo_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoDescuento(descuento))
            {
                ret = Nacional.ErroresAltaExcursion.Descuento_Invalido;
            }
            else
            {
                Excursion aux = CExcursion.Instancia.BuscarExcursion(codigo);
                if (aux == null)
                {
                    aux = CExcursion.Instancia.CrearExcursionInternacional(codigo, descripcion, fechaInicio, diasTraslado,
                  stockDisponible, puntos, costoDiario, descuento, cantDias, destinos);
                    if (AgregarDestinos(cantDias, destinos, aux))
                    {
                        CExcursion.Instancia.AltaExcursion(aux);
                    }
                    else
                    {
                        ret = Nacional.ErroresAltaExcursion.Destino_Invalido;
                    }
                }
                else
                {
                    ret = Nacional.ErroresAltaExcursion.Cod_Repetido;
                }
            }
            return ret;
        }
        #endregion

        #region ALTA EXCURSION INTRNACIONAL
        public Internacional.ErroresAltaExcursion AltaExcursionNacional(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
            int puntos, double costoDiario, List<string> destinos, List<int> cantDias)
        {
            Internacional.ErroresAltaExcursion ret = Internacional.ErroresAltaExcursion.OK;
            if (!CExcursion.Instancia.ValidoCodigo(codigo))
            {
                ret = Internacional.ErroresAltaExcursion.Cod_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoDescripcion(descripcion))
            {
                ret = Internacional.ErroresAltaExcursion.Desc_Vaicia;
            }
            else if (!CExcursion.Instancia.ValidoFechaInicio(fechaInicio))
            {
                ret = Internacional.ErroresAltaExcursion.Fi_Invalida;
            }
            else if (!CExcursion.Instancia.ValidoDiasTraslado(diasTraslado))
            {
                ret = Internacional.ErroresAltaExcursion.DiasTraslado_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoStockDisponible(stockDisponible))
            {
                ret = Internacional.ErroresAltaExcursion.Stock_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoPuntos(puntos))
            {
                ret = Internacional.ErroresAltaExcursion.Puntos_Invalido;
            }
            else if (!CExcursion.Instancia.ValidoCostoDiario(costoDiario))
            {
                ret = Internacional.ErroresAltaExcursion.Costo_Invalido;
            }
            else
            {
                Excursion aux = CExcursion.Instancia.BuscarExcursion(codigo);
                if (aux == null)
                {
                    aux = CExcursion.Instancia.CrearExcursionInternacional(codigo, descripcion, fechaInicio, diasTraslado,
                        stockDisponible, puntos, costoDiario, cantDias, destinos);
                    if (AgregarDestinos(cantDias, destinos, aux))
                    {
                        CExcursion.Instancia.AltaExcursion(aux);
                    }
                    else
                    {
                        ret = Internacional.ErroresAltaExcursion.Destino_Invalido;
                    }
                }
                else
                {
                    ret = Internacional.ErroresAltaExcursion.Cod_Repetido;
                }
            }
            return ret;
        }
        #endregion

        #region AGREGAR DESTINOS A EXCURSION

        public bool AgregarDestinos(List<int> cantDias, List<string> destinos, Excursion aux)
        {
            bool ret = true;
            int i = 0;
            if (aux != null)
            {
                while (i < destinos.Count && ret)
                {
                    Destino destino = CDestino.Instancia.BuscarDestinoPorNombre(destinos[i]);
                    if (destino != null)
                    {
                        ret = CExcursion.Instancia.AgregarDestinos(cantDias[i], destino, aux);
                    }
                    else
                    {
                        ret = false;
                    }
                    i++;
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        #endregion

        #region LISTADOS DESTINOS

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
