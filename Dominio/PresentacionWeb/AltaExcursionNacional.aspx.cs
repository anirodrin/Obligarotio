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
            instancia.AltaDestinio("nombre1", "pais1", "ciudad1", true);
            instancia.AltaDestinio("nombre2", "pais2", "ciudad2", true);
            instancia.AltaDestinio("nombre3", "pais3", "ciudad3", true);
            instancia.AltaDestinio("nombre4", "pais4", "ciudad4", true);
            //this.lblMensajes.Visible = false;
            if (!IsPostBack)
            {
                this.grvDestinos.DataSource = instancia.ListadoDestinosNacionales();
                this.grvDestinos.DataBind();
                this.lblMensajes.Text = "";
            }
        }

        protected void txtGuardar_Click(object sender, EventArgs e)
        {
            bool ret = true;
            int diasTraslado;
            ret = int.TryParse(this.txtDiasTraslado.Text, out diasTraslado);
            if (!ret)
            {
                this.lblMensajes.Text = "La cantidad de dias debe ser numerica";
                this.lblMensajes.Visible = true;
            }
            else 
            {
                double costoDiario;
                ret = double.TryParse(this.txtCostoDiario.Text, out costoDiario);
                if (!ret)
                {
                    this.lblMensajes.Text = "El costo diario debe ser numerico";
                    this.lblMensajes.Visible = true;
                }
                else 
                {
                    int puntos;
                    ret = int.TryParse(this.txtPuntos.Text, out puntos);
                    if (!ret)
                    {
                        this.lblMensajes.Text = "La cantidad de puntos debe ser numerico";
                        this.lblMensajes.Visible = true;
                    }
                    else 
                    {
                        this.lblMensajes.Text = "";
                        this.lblMensajes.Visible = false;
                        Agencia instancia = new Agencia();
                        //instancia.AltaExcursionNacional(this.txtCodigo, this.txtDescripcion, 
                        //    this.
                    }
                }
            }
        }
    }
}