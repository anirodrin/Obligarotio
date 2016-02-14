using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DestinoExcursion
    {

        #region ATRIBUTOS
        private Destino destino;
        private int cantDias;
        #endregion

        #region PROPIEDADES
        public Destino Destino
        {
            get { return this.destino; }
        }
        #endregion

        #region CONSTRUCTOR

        public DestinoExcursion(Destino destino, int cantDias) 
        {
            this.destino = destino;
            this.cantDias = cantDias;
        }

        #endregion
    }
}
