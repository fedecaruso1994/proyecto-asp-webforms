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
                // configuracion incial de la pantalla 
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    cargarCombo(ddlTipo, negocio.listar());
                    cargarCombo(ddlDebilidad, negocio.listar());
                }
                // configuracion si estamos modificando. 
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //List<Pokemon> lista = negocio.listar(id);
                    //Pokemon seleccionado = lista[0];
                    Pokemon seleccionado = (negocio.listar(id))[0];

                    //Pre cargar datos 
                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtUrl.Text = seleccionado.UrlImagen;
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txtUrl_TextChanged(sender, e);

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
                    UrlImagen = txtUrl.Text,
                    Tipo = new Elemento
                    {
                        Id = int.Parse(ddlTipo.SelectedValue)
                    },
                    Debilidad = new Elemento
                    {
                        Id = int.Parse(ddlDebilidad.SelectedValue)
                    }

                };
                if (Request.QueryString["id"] != null) {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificarConSP(nuevo);
                }
                else
                    negocio.agregarConSP(nuevo);

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

        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            imgDetalle.ImageUrl = txtUrl.Text;
        }
    }
}