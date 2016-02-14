using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Internacional: Excursion
    {
        #region ATRIBUTOS
        public static double costoSeguro;
        #endregion

        #region CONSTRUCTOR
        public Internacional(string codigo, string descripcion, DateTime fechaInicio, int diasTraslado, int stockDisponible,
      int puntos, double costoDiario)
            : base(codigo, descripcion, fechaInicio, diasTraslado, stockDisponible, puntos, costoDiario)
        {

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
    }
}
