using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace pokedex_web
{
    public partial class DetallePokemon : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
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
                    Pokemon seleccionado = (negocio.listar(id))[0];
                    // guardo pokemon seleccionado en session 
                    Session.Add("pokeSeleccionado", seleccionado);
                    //Pre cargar datos 
                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtUrl.Text = seleccionado.UrlImagen;
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txtUrl_TextChanged(sender, e);

                    //configurar acciones 
                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Rectivar";

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void ConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            if (chkConfiraEliminacion.Checked)
            {
                try
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("PokemonList.aspx", false);

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    //luego agregar un redireccion a una pantalla de error. 
                }
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("PokemonList.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                //luego agregar un redireccion a una pantalla de error. 
            }
        }
    }
}