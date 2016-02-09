using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class CContrato
    {
        #region ATRIBUTOS
        public List<Contrato> destinos = new List<Contrato>();
        #endregion

        #region SINGLETON
        private static CContrato instancia;

        public static CContrato Instancia
        {
            get
            {
                if (CContrato.instancia == null)
                {
                    instancia = new CContrato();
                }
                return CContrato.instancia;
            }
        }

        private CContrato() { }
        #endregion
    }
}
