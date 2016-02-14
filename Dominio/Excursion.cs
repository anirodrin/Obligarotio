using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {
        #region ATRIBUTOS
        private string codigo;
        private string descrpcion;
        private DateTime fechaInicio;
        private int diasTraslado;
        private int stockDisponible;
        private int puntos;
        private double costoDiario;
        private DestinoExcursion destinos;

        #endregion

    }
}
