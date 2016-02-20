using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CContrato
    {
        #region ATRIBUTOS
        public List<Contrato> contratos = new List<Contrato>();
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

        #region LISTADO DE EXCURSIONES CONTRATADAS ENTRE DOS FECHAS
        public List<Excursion> ListadoExcursionesContratadasEntreDosFechas(DateTime fInicio, DateTime fFin) 
        {
            List<Excursion> listado = new List<Excursion>();

            foreach (Contrato unC in this.contratos) 
            {
                if (unC.ContratoEntreFechas(fInicio, fFin)) 
                {
                    if (!listado.Contains(unC.Excursion)) 
                    {
                        listado.Add(unC.Excursion);
                    }
                }
            }
            return listado;
        }
        #endregion
    }
}
