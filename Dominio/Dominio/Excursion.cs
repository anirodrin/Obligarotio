using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {
        #region ATRIBUTOS
        private string codigo;
        private string descripcion;
        private DateTime fechaInicio;
        private int diasTraslado;
        private int stockDisponible;
        private int puntos;
        private double costoDiario;
        private List<DestinoExcursion> destinos;
        private int diasTotales;
        #endregion

        #region PROPIEDADES


        public string Codigo
        {
            get { return this.codigo; }
        }

        public List<DestinoExcursion> Destinos
        {
            get { return this.destinos; }
        }
        #endregion

        #region CONSTRUCTOR
        public Excursion(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
            int puntos, double costoDiario)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.diasTraslado = diasTraslado;
            this.stockDisponible = stockDisponible;
            this.puntos = puntos;
            this.costoDiario = costoDiario;
            this.diasTotales = diasTraslado;
        }
        #endregion

        #region BUSQUEDA DE DESTINO EN EXCURSION

        public bool TieneDestino(Destino destino)
        {
            bool ret = false;
            int i = 0;

            while (i < this.destinos.Count && !ret)
            {
                if (this.destinos[i].Destino == destino)
                {
                    ret = true;
                }
                i++;
            }
            return ret;
        }

        #endregion

        #region VALIDACIONES ALTA EXCURSION
        public static bool ValidoCodigo(string codigo)
        {
            bool ret = !string.IsNullOrEmpty(codigo);
            if (ret)
            {
                ret = Regex.IsMatch(codigo, "^[^a-zA-Z0-9]");
            }
            return ret;
        }

        public static bool ValidoDescripcion(string descripcion)
        {
            return !string.IsNullOrEmpty(descripcion);
        }

        public static bool ValidoFechaInicio(DateTime fechaInicio)
        {
            bool ret = fechaInicio != null;
            if (ret)
            {
                ret = fechaInicio >= DateTime.Today;
            }
            return ret;
        }

        public static bool ValidoDiasTraslado(int diasTraslado)
        {
            return diasTraslado > 0;
        }

        public static bool ValidoStockDisponible(int stockDisponible)
        {
            return stockDisponible > 0;
        }

        public static bool ValidoPuntos(int puntos)
        {
            return puntos > 0;
        }

        public static bool ValidoCostoDiario(double costoDiario)
        {
            return costoDiario > 0;

        }

        public static bool ValidoCantDias(int dias) 
        {
            return dias > 0;
        }
        #endregion

        #region AGEREGAR DESTINOS

        public bool AgregarDestinos(int cant, Destino destino) 
        {
            bool ret = true;

            if (Excursion.ValidoCantDias(cant) && destino!= null) 
            {
            DestinoExcursion aux = new DestinoExcursion(destino, cant);
            this.destinos.Add(aux);
            this.diasTotales += cant;
            }
            return ret;
        }

        #endregion

        #region OVERRIDE METODO EQUALS
        public override bool Equals(object obj)
        {
            bool ret = false;
            Excursion aux = obj as Excursion;
            if (aux != null)
            {
                ret = this.codigo == aux.codigo;
            }
            return ret;
        }

        #endregion
    }
}
