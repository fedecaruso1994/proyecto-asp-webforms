using System;
using System.Collections.Generic;
using negocio;
using dominio;

namespace pokedex_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> pokemons { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            pokemons = negocio.listarConSP();
        }
    }
}