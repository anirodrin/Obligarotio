using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class CDestino
    {
         #region ATRIBUTOS
        public List<Destino> destinos = new List<Destino>();
        #endregion

        #region SINGLETON
        private static CDestino instancia;

        public static CDestino Instancia
        {
            get
            {
                if (CDestino.instancia == null)
                {
                    instancia = new CDestino();
                }
                return CDestino.instancia;
            }
        }

        private CDestino() { }
        #endregion
    }
}
