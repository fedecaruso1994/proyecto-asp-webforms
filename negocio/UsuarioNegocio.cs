using System;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            bool logueado = false;

            try
            {
                datos.setearConsulta("Select Id, TipoUser from Usuarios where Usuario= @user and Pass = @pass");
                datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    {
                        usuario.Id = (int)datos.Lector["Id"];
                        usuario.Tipo = (UserType)(int)datos.Lector["TipoUser"];
                    }
                    logueado = true;
                }
                else
                {
                    logueado = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return logueado;
        }
    }
}
