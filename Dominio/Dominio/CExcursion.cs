using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CExcursion
    {
        #region ATRIBUTOS
        public List<Excursion> excursiones = new List<Excursion>();
        #endregion

        #region SINGLETON
        private static CExcursion instancia;

        public static CExcursion Instancia
        {
            get
            {
                if (CExcursion.instancia == null)
                {
                    instancia = new CExcursion();
                }
                return CExcursion.instancia;
            }
        }

        private CExcursion() { }
        #endregion

    }
}
