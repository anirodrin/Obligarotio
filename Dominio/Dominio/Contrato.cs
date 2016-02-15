using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Contrato
    {
        public List<Pasajero> pasajeros = new List<Pasajero>();
        private Excursion excursion;
        private DateTime fechaContrato;
        public double precio;

        public Excursion Excursion
        {
            get { return this.excursion; }
        }

        public bool ContratoEntreFechas(DateTime fInicio, DateTime fFin) 
        {
            return this.fechaContrato <= fFin && this.fechaContrato >= fInicio;
        }
    }
}
