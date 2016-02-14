using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aplicacion;

namespace PresentacionWeb
{
    public partial class AltaExcursion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Agencia instancia = new Agencia();
            //List<Destino> destinos = instancia.ListadoDestinos();
            if (!IsPostBack)
            {
                this.grvDestinos.DataSource = instancia.ListadoDestinosNacionales();
                this.grvDestinos.DataBind();
            }
        }
    }
}