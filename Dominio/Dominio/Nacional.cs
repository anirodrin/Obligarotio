using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacional: Excursion
    {
        #region ATRIBUTOS
        public int descuento;
        #endregion

        #region CONSTRUCTOR
        public Nacional(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
            int puntos, double costoDiario, int descuento)
            : base(codigo, descripcion, fechaInicio, diasTraslado, stockDisponible, puntos, costoDiario) 
        {
            this.descuento = descuento;
        }
        #endregion

        #region ERRORES ALTA EXCURSION

        public enum ErroresAltaExcursion
        {
            OK,
            Cod_Invalido,
            Cod_Repetido,
            Desc_Vaicia,
            Fi_Invalida,
            Costo_Invalido,
            DiasTraslado_Invalido,
            Stock_Invalido,
            Puntos_Invalido,
            Descuento_Invalido,
            Destino_Invalido

        }
        #endregion

        #region VALIDO DESCUENTO

        public static bool ValidoDescuento(int descuento)
        {
            return descuento > 0;
        }

        #endregion
    }
}
