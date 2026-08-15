using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;

namespace pokedex_web
{
    public partial class DetallePokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    cargarCombo(ddlTipo, negocio.listar());
                    cargarCombo(ddlDebilidad, negocio.listar());
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw; //luego agregar un redireccion a una pantalla de error. 
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon nuevo = new Pokemon
                {
                    Numero = int.Parse(txtNumero.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    // agregar url imagen 
                    Tipo = new Elemento
                    {
                        Id = int.Parse(ddlTipo.SelectedValue)
                    },
                    Debilidad = new Elemento
                    {
                        Id = int.Parse(ddlDebilidad.SelectedValue)
                    }

                };

                negocio.agregar(nuevo); // Esto no va a andarp orque falta la imagen 
                Response.Redirect("PokemonList.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw; //luego agregar un redireccion a una pantalla de error. 
            }
        }

        private void cargarCombo(DropDownList combo, List<Elemento> lista)
        {
            combo.DataSource = lista;
            combo.DataTextField = "Descripcion";
            combo.DataValueField = "Id";
            combo.DataBind();
        }
    }
}