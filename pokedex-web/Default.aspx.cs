using System;
using System.Collections.Generic;
using negocio;
using dominio;
using System.Web.UI.WebControls;

namespace pokedex_web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PokemonNegocio pokemonNegocio = new PokemonNegocio();
                ElementoNegocio elementoNegocio = new ElementoNegocio();

                List<Pokemon> pokemons = pokemonNegocio.listarConSP();
                List<Elemento> elementos = elementoNegocio.listar();

                Session["listaPokemon"] = pokemons;

                cargarPokemon(pokemons);
                cargarCombo(ddlTipo, elementos);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Pokemon> pokemons = (List<Pokemon>)Session["listaPokemon"];

            int idTipo = int.Parse(ddlTipo.SelectedValue);

            if (idTipo == 0)
            {
                cargarPokemon(pokemons);
            }
            else
            {
                List<Pokemon> filtrados =pokemons.FindAll(x => x.Tipo.Id == idTipo);
                cargarPokemon(filtrados);
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
        }

        private void cargarPokemon(List<Pokemon> pokemons)
        {
            repRepetidor.DataSource = pokemons;
            repRepetidor.DataBind();
        }

        private void cargarCombo(DropDownList combo, List<Elemento> lista)
        {
            combo.DataSource = lista;
            combo.DataTextField = "Descripcion";
            combo.DataValueField = "Id";
            combo.DataBind();

            combo.Items.Insert(0, new ListItem("Todos", "0"));
        }
    }
}