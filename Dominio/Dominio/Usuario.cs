using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario
    {
        public string nombreUsuario;
        public string password;
        public Rol rol;

        public enum Rol
        {
            Administrador,
            Gerente,
            Vendedor
        }
    }
}
