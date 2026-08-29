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
            List<Pokemon> listaFiltrada = ((List<Pokemon>)Session["listaPokemon"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) );
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }
    }
}