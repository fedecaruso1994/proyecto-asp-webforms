using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum UserType
    {
        NORMAL = 1,
        ADMIN = 2
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public UserType Tipo { get; set; }

        public Usuario(string user, string pass, bool admin)
        {
            User = user;
            Pass = pass;
            Tipo = admin ? UserType.ADMIN : UserType.NORMAL;
        }
    }
}
