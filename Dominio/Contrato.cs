using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Contrato
    {
        public List<Pasajero> pasajeros = new List<Pasajero>();
        public Excursion excursion;
        public DateTime fechaContrato;
        public double precio;
    }
}
