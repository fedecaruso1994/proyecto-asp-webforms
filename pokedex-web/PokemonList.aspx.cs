using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace pokedex_web
{
    public partial class PokemonList : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    cargarGrilla();
            }
            catch (Exception ex)
            {
                //Session["error"] = ex;
                //Response.Redirect("Error.aspx");
                throw ex;
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("DetallePokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallePokemon.aspx");
        }

        private void cargarGrilla()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("listaPokemon", negocio.listarConSP());
            dgvPokemons.DataSource = Session["listaPokemon"];
            dgvPokemons.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada = ((List<Pokemon>)Session["listaPokemon"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroSimple.Text.ToUpper()) );
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }
        protected void checkBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
           txtFiltroSimple.Enabled = !checkBoxFiltroAvanzado.Checked;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txbFiltro.Text, ddlEstado.SelectedItem.ToString());
                dgvPokemons.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}